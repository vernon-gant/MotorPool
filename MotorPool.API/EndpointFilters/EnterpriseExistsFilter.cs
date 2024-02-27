using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Enterprise.Services;

namespace MotorPool.API.EndpointFilters;

public class EnterpriseExistsFilter(EnterpriseQueryService enterpriseQueryService) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        int enterpriseId = int.Parse(context.HttpContext.Request.RouteValues["enterpriseId"]!.ToString());

        EnterpriseViewModel? enterprise = await enterpriseQueryService.GetByIdAsync(enterpriseId);

        if (enterprise is not null)
        {
            context.HttpContext.Items["Enterprise"] = enterprise;
            return await next(context);
        }

        context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        return null;
    }

}