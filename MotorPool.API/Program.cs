using System.Text.Json;

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

builder.Services.AddPersistence(connectionString);
builder.Services.AddVehicleServices();
builder.Services.AddVehicleBrandServices();
builder.Services.AddEnterpriseServices();
builder.Services.AddDriverServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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


app.MapGet("vehicles", async (VehicleService vehicleService) => await vehicleService.GetAllAsync());

app.MapGet("vehicle-brands", async (VehicleBrandService vehicleBrandService) => await vehicleBrandService.GetAllAsync());

app.MapGet("enterprises", async (EnterpriseService enterpriseService) => await enterpriseService.GetAllAsync());

app.MapGet("drivers", async (DriverService driverService) => await driverService.GetAllAsync());

await app.SetupDatabaseAsync();

app.Run();