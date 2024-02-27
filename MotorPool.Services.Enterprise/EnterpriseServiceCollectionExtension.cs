using Microsoft.Extensions.DependencyInjection;

using MotorPool.Services.Enterprise.Services;
using MotorPool.Services.Enterprise.Services.Concrete;

namespace MotorPool.Services.Enterprise;

public static class EnterpriseServiceExtension
{

    public static void AddEnterpriseServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EnterpriseServiceExtension));
        services.AddScoped<EnterpriseQueryService, DefaultEnterpriseQueryService>();
        services.AddScoped<EnterpriseActionService, DefaultEnterpriseActionService>();
    }

}