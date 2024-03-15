using Microsoft.Extensions.DependencyInjection;

using MotorPool.Services.Geo.Services;
using MotorPool.Services.Geo.Services.Concrete;

namespace MotorPool.Services.Geo;

public static class GeoServiceCollectionExtension
{

    public static void AddGeoServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(GeoServiceCollectionExtension));
        services.AddScoped<GeoQueryService, DefaultGeoQueryService>();
    }

}