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
using MotorPool.Auth.Manager;
using MotorPool.Persistence;
using MotorPool.Services.Drivers;
using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Enterprise;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Enterprise.Services;
using MotorPool.Services.Manager;
using MotorPool.Services.VehicleBrand;
using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles;
using MotorPool.Services.Vehicles.Exceptions;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

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
builder.Services.AddAuthentication(options => {
           options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       }).AddJwtBearer(options => { options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key)),
        ValidIssuer = jwtConfig.Issuer,
        ValidAudience = jwtConfig.Audience,
        ValidateIssuer = false,
        ValidateAudience = false
    }; });
builder.Services.AddAuthorization(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
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
builder.Services.ConfigureHttpJsonOptions(o => {
    o.SerializerOptions.AllowTrailingCommas = true;
    o.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    o.SerializerOptions.PropertyNameCaseInsensitive = true;
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
    app.UseSwagger();
    app.UseSwaggerUI();
}

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