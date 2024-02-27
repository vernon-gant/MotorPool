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
        RouteGroupBuilder driversGroupBuilder = managerResourcesGroupBuilder.MapGroup("/drivers");

        driversGroupBuilder.MapGetAll();
    }

    private static void MapGetAll(this IEndpointRouteBuilder driversGroupBuilder)
    {
        driversGroupBuilder.MapGet("", async (DriverQueryService driverService, ClaimsPrincipal principal) =>
        {
            List<DriverViewModel> drivers = await driverService.GetAllAsync();

            int managerId = principal.GetManagerId();

            return drivers.ForManager(managerId);
        });
    }

}