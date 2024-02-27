using MotorPool.Services.Enterprise.Models;

namespace MotorPool.API.EndpointFilters;

public class IsManagerAccessibleEnterpriseFilter : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        EnterpriseViewModel currentEnterprise = context.HttpContext.Items["Enterprise"] as EnterpriseViewModel ??
                                                throw new InvalidOperationException("Enterprise not found in the request context.");

        if (currentEnterprise.ManagerIds.Contains(context.HttpContext.User.GetManagerId())) return await next(context);

        context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

        return null;
    }

}