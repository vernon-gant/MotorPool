using Microsoft.Extensions.DependencyInjection;

namespace MotorPool.Services.Drivers;

public static class DriverServiceExtension
{

    public static void AddDriverServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DriverServiceExtension));
    }

}