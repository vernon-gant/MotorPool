using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Manager;

namespace MotorPool.API.EndpointFilters;

public class IsManagerAccessibleEnterpriseFilter : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        FullEnterpriseViewModel currentFullEnterprise = context.HttpContext.Items["Enterprise"] as FullEnterpriseViewModel ??
                                                throw new InvalidOperationException("Enterprise not found in the request context.");

        if (currentFullEnterprise.ManagerIds.Contains(context.HttpContext.User.GetManagerId())) return await next(context);

        context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

        return null;
    }

}