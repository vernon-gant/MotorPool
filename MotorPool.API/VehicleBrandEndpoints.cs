using MotorPool.Services.VehicleBrand.Services;

namespace MotorPool.API;

public static class VehicleBrandEndpoints
{

    public static void MapVehicleBrandEndpoints(this WebApplication app)
    {
        RouteGroupBuilder vehicleBrandsGroupBuilder = app.MapGroup("/vehicle-brands");

        vehicleBrandsGroupBuilder.MapGetAll();
    }

    private static void MapGetAll(this IEndpointRouteBuilder vehiclesGroupBuilder)
    {
        vehiclesGroupBuilder.MapGet("", async (VehicleBrandService vehicleBrandService) => await vehicleBrandService.GetAllAsync());
    }

}