using System.Security.Claims;
using MotorPool.Persistence.QueryObjects;
using MotorPool.Repository.Driver;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Manager;

namespace MotorPool.API.Endpoints;

public static class DriverEndpoints
{

    public static void MapDriverEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder driversGroupBuilder = managerResourcesGroupBuilder
                                                .MapGroup("drivers")
                                                .WithParameterValidation();

        driversGroupBuilder.MapGet("", GetAll)
                           .WithName("GetAllDrivers")
                           .Produces<List<DriverViewModel>>();
    }

    private static async Task<IResult> GetAll(DriverQueryRepository driverQueryRepository, ClaimsPrincipal principal, [AsParameters] PageOptionsDTO pageOptions)
    {
        int managerId = principal.GetManagerId();

        return Results.Ok(await driverQueryRepository.GetAllAsync(managerId, pageOptions.ToPageOptions()));
    }

}