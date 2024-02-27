using System.Security.Claims;

using MotorPool.API.EndpointFilters;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Enterprise.Services;
using MotorPool.Services.Manager;

namespace MotorPool.API.Endpoints;

public static class EnterpriseEndpoints
{

    public static void MapEnterpriseEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder enterprisesGroupBuilder = managerResourcesGroupBuilder.MapGroup("/enterprises");

        enterprisesGroupBuilder.MapGetAll();
    }

    private static void MapGetAll(this IEndpointRouteBuilder enterprisesGroupBuilder)
    {
        enterprisesGroupBuilder.MapGet("", async (EnterpriseQueryService enterpriseService, ClaimsPrincipal user) =>
        {
            int managerId = user.GetManagerId();

            List<EnterpriseViewModel> allEnterprises = await enterpriseService.GetAllAsync();

            return allEnterprises.ForManager(managerId);
        });
    }

}