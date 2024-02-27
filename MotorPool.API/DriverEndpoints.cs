using System.Security.Claims;

using MotorPool.Auth.EndpointFilters;
using MotorPool.Auth.Manager;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Manager;

namespace MotorPool.API;

public static class DriverEndpoints
{

    public static void MapDriverEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder driversGroupBuilder = managerResourcesGroupBuilder.MapGroup("/drivers");

        driversGroupBuilder.MapGetAll();
    }

    private static void MapGetAll(this IEndpointRouteBuilder driversGroupBuilder)
    {
        driversGroupBuilder.MapGet("drivers", async (DriverQueryService driverService, ClaimsPrincipal principal) =>
        {
            List<DriverViewModel> drivers = await driverService.GetAllAsync();

            int managerId = principal.GetManagerId();

            return drivers.ForManager(managerId);
        });
    }

}