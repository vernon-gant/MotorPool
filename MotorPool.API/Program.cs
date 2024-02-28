using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using MotorPool.API.EndpointFilters;
using MotorPool.API.Endpoints;
using MotorPool.Auth;
using MotorPool.Auth.Middleware;
using MotorPool.Auth.Services;
using MotorPool.Persistence;
using MotorPool.Services.Drivers;
using MotorPool.Services.Enterprise;
using MotorPool.Services.VehicleBrand;
using MotorPool.Services.Vehicles;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
JWTConfig jwtConfig = new ();
builder.Configuration.GetSection("JWTConfig").Bind(jwtConfig);
builder.Services.AddSingleton(jwtConfig);
builder.Services.AddScoped<ApiAuthService, DefaultApiAuthService>();

builder.Services.AddPersistenceServices(connectionString);
builder.Services.AddVehicleServices();
builder.Services.AddVehicleBrandServices();
builder.Services.AddEnterpriseServices();
builder.Services.AddDriverServices();
builder.Services.AddAppIdentity(connectionString);
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
builder.Services.AddAppAuthorization();


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
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.AllowTrailingCommas = true;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseUnauthorizedOnNotManagerAccess();
app.UseAuthorization();

app.MapVehicleBrandEndpoints();

app.MapAuthEndpoints();

RouteGroupBuilder managerResourcesGroupBuilder = app.MapGroup("/")
                                                    .RequireAuthorization()
                                                    .AddEndpointFilter<ManagerExistenceFilter>();

managerResourcesGroupBuilder.MapVehicleEndpoints();

managerResourcesGroupBuilder.MapDriverEndpoints();

managerResourcesGroupBuilder.MapEnterpriseEndpoints();

await app.SetupDatabaseAsync();

app.Run();