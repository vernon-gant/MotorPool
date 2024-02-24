using System.Security.Claims;
using System.Text;
using System.Text.Json;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using MotorPool.API;
using MotorPool.Auth;
using MotorPool.Persistence;
using MotorPool.Services.Drivers;
using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Enterprise;
using MotorPool.Services.Enterprise.Services;
using MotorPool.Services.VehicleBrand;
using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles;
using MotorPool.Services.Vehicles.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
JWTConfig jwtConfig = new ();
builder.Configuration.GetSection("JWTConfig").Bind(jwtConfig);
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddPersistenceServices(connectionString);
builder.Services.AddVehicleServices();
builder.Services.AddVehicleBrandServices();
builder.Services.AddEnterpriseServices();
builder.Services.AddDriverServices();
builder.Services.AddAuthServices(connectionString);
builder.Services.AddScoped<ApiAuthService, DefaultApiAuthService>();

builder.Services
       .AddAuthentication(options =>
       {
           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       })
       .AddJwtBearer(options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
               ValidIssuer = jwtConfig.Issuer,
               ValidAudience = jwtConfig.Audience,
               ValidateIssuer = false,
               ValidateAudience = false
           };
       });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsManager", policy => policy.RequireClaim("ManagerId"));
    options.AddPolicy("IsManagerAccessible", policy => policy.Requirements.Add(new IsManagerAccessibleRequirement()));

    options.DefaultPolicy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .RequireClaim("ManagerId")
                            .Build();
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    OpenApiSecurityScheme jwtSecurityScheme = new ()
    {
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
        Name = "JWT Authentication",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
builder.Services.AddProblemDetails();

builder.Services.ConfigureHttpJsonOptions(o =>
{
    o.SerializerOptions.AllowTrailingCommas = true;
    o.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    o.SerializerOptions.PropertyNameCaseInsensitive = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
    app.UseSwagger();
    app.UseSwaggerUI();
}

var managerResourcesGroup = app.MapGroup("/").AddEndpointFilter<ManagerExistenceFilter>();

managerResourcesGroup.MapGet("vehicles", async (VehicleService vehicleService, ClaimsPrincipal user) =>
                     {
                         var managerId = int.Parse(user.FindFirstValue("ManagerId")!);

                         return await vehicleService.GetAllByManagerIdAsync(managerId);
                     })
                     .RequireAuthorization("IsManager")
                     .AddEndpointFilter<ManagerExistenceFilter>();

app.MapGet("vehicle-brands", async (VehicleBrandService vehicleBrandService) => await vehicleBrandService.GetAllAsync());

managerResourcesGroup.MapGet("enterprises", async (EnterpriseService enterpriseService, ClaimsPrincipal user) =>
{
    var managerId = int.Parse(user.FindFirstValue("ManagerId")!);

    return await enterpriseService.GetAllByManagerIdAsync(managerId);
});

managerResourcesGroup.MapGet("drivers", async (DriverService driverService, ClaimsPrincipal principal) =>
{
    var managerId = int.Parse(principal.FindFirstValue("ManagerId")!);

    return await driverService.GetByManagerIdAsync(managerId);
});

app.MapPost("login", async (ApiAuthService authService, LoginDTO loginDTO) =>
{
    var result = await authService.LoginAsync(loginDTO);

    return result.IsSuccess
        ? Results.Ok(new { result.Token })
        : Results.Problem(new ProblemDetails
        {
            Title = "Login failed",
            Status = 400,
            Detail = result.Error
        });
});

app.MapPost("register", async (ApiAuthService authService, RegisterDTO registerDTO) =>
{
    var result = await authService.RegisterAsync(registerDTO);

    return result.IsSuccess
        ? Results.Ok(new { result.Token })
        : Results.Problem(new ProblemDetails
        {
            Title = "Registration failed",
            Status = 400,
            Detail = result.Error
        });
});

app.MapGet("me", async (ApiAuthService authService, ClaimsPrincipal principal) =>
   {
       var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

       if (userId == null) return Results.Unauthorized();

       return Results.Ok(await authService.GetUserAsync(userId));
   })
   .RequireAuthorization()
   .Produces<UserViewModel>();

await app.SetupDatabaseAsync();

app.Run();