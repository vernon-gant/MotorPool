using MotorPool.Services.VehicleBrand.Models;
using MotorPool.Services.VehicleBrand.Services;

namespace MotorPool.API.Endpoints;

public static class VehicleBrandEndpoints
{

    public static void MapVehicleBrandEndpoints(this WebApplication app)
    {
        RouteGroupBuilder vehicleBrandsGroupBuilder = app.MapGroup("vehicle-brands");

        vehicleBrandsGroupBuilder.MapGet("", GetAll)
                                 .WithName("GetAllVehicleBrands")
                                 .Produces<List<VehicleBrandViewModel>>();
    }

    private static async Task<IResult> GetAll(VehicleBrandService vehicleBrandService) => Results.Ok(await vehicleBrandService.GetAllAsync());

}