using System.Security.Claims;

using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Manager;
using MotorPool.Services.Utils;

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

    private static async Task<IResult> GetAll(DriverQueryService driverService, ClaimsPrincipal principal, [AsParameters] PageOptionsDTO pageOptions)
    {
        int managerId = principal.GetManagerId();

        return Results.Ok(await driverService.GetAllAsync(managerId, pageOptions.ToPageOptions()));
    }

}