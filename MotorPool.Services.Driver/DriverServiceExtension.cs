using Microsoft.Extensions.DependencyInjection;

using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Drivers.Services.Concrete;

namespace MotorPool.Services.Drivers;

public static class DriverServiceExtension
{

    public static void AddDriverServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DriverServiceExtension));
        services.AddScoped<DriverService, DefaultDriverService>();
    }

}