using System.Security.Claims;

using MotorPool.API.EndpointFilters;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Manager;

namespace MotorPool.API.Endpoints;

public static class DriverEndpoints
{

    public static void MapDriverEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder driversGroupBuilder = managerResourcesGroupBuilder.MapGroup("drivers");

        driversGroupBuilder.MapGet("", GetAll)
                          .WithName("GetAllDrivers")
                          .Produces<List<DriverViewModel>>();
    }

    private static async Task<IResult> GetAll(DriverQueryService driverService, ClaimsPrincipal principal)
    {
        List<DriverViewModel> drivers = await driverService.GetAllAsync();

        int managerId = principal.GetManagerId();

        return Results.Ok(drivers.ForManager(managerId));
    }

}