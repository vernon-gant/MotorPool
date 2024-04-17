using Microsoft.Extensions.DependencyInjection;

using MotorPool.Services.Vehicles.Services;
using MotorPool.Services.Vehicles.Services.Concrete;

namespace MotorPool.Services.Vehicles;

public static class VehicleServicesExtension
{

    public static void AddVehicleServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(VehicleServicesExtension));
        services.AddScoped<VehicleActionService, DefaultVehicleActionService>();
        services.AddScoped<VehicleQueryService, DefaultVehicleQueryService>();
    }

}