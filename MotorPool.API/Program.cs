using System.Security.Claims;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;

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

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
JWTConfig jwtConfig = new ();
builder.Configuration.GetSection("JWTConfig").Bind(jwtConfig);
builder.Services.AddSingleton(jwtConfig);

builder.Services.AddPersistenceServices(connectionString);
builder.Services.AddVehicleServices();
builder.Services.AddVehicleBrandServices();
builder.Services.AddEnterpriseServices();
builder.Services.AddDriverServices();
builder.Services.AddAuthServices(jwtConfig, connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

builder.Services.ConfigureHttpJsonOptions(o =>
{
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

app.MapGet("vehicles", async (VehicleService vehicleService, ClaimsPrincipal user) =>
   {
       int managerId = int.Parse(user.FindFirstValue("ManagerId")!);

       return await vehicleService.GetByManagerAsync(managerId);
   })
   .RequireAuthorization("IsManager")
   .AddEndpointFilter<ManagerExistenceFilter>();

app.MapGet("vehicle-brands", async (VehicleBrandService vehicleBrandService) => await vehicleBrandService.GetAllAsync());

app.MapGet("enterprises", async (EnterpriseService enterpriseService, ClaimsPrincipal user) =>
   {
       int managerId = int.Parse(user.FindFirstValue("ManagerId")!);

       return await enterpriseService.GetByManagerAsync(managerId);
   })
   .RequireAuthorization("IsManager")
   .AddEndpointFilter<ManagerExistenceFilter>();

app.MapGet("drivers", async (DriverService driverService, ClaimsPrincipal principal) =>
   {
       int managerId = int.Parse(principal.FindFirstValue("ManagerId")!);

       return await driverService.GetByManagerAsync(managerId);
   })
   .RequireAuthorization("IsManager")
   .AddEndpointFilter<ManagerExistenceFilter>();

app.MapPost("login", async (AuthService authService, LoginDTO loginDTO) =>
{
    AuthResult result = await authService.LoginAsync(loginDTO);

    return result.IsSuccess
        ? Results.Ok(new { result.Token })
        : Results.Problem(new ProblemDetails
        {
            Title = "Login failed",
            Status = 400,
            Detail = result.Error
        });
});

app.MapPost("register", async (AuthService authService, RegisterDTO registerDTO) =>
{
    AuthResult result = await authService.RegisterAsync(registerDTO);

    return result.IsSuccess
        ? Results.Ok(new  { result.Token })
        : Results.Problem(new ProblemDetails
        {
            Title = "Registration failed",
            Status = 400,
            Detail = result.Error
        });
});

app.MapGet("me", async (AuthService authService, ClaimsPrincipal principal) =>
   {
       string? userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

       if (userId == null) return Results.Unauthorized();

       return Results.Ok(await authService.GetUserAsync(userId));
   })
   .RequireAuthorization()
   .Produces<UserViewModel>();

await app.SetupDatabaseAsync();

app.Run();