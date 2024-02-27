using Microsoft.EntityFrameworkCore;

using MotorPool.Abstractions;
using MotorPool.Auth.EndpointFilters;
using MotorPool.Persistence;

namespace MotorPool.Auth.Manager;

public class EnterpriseIsManagerAccessibleFilter(AppDbContext dbContext) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        EnterpriseOwned? enterpriseOwnedEntity = context.HttpContext.Request.RouteValues.Values.FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(EnterpriseOwned))) as EnterpriseOwned;

        if (enterpriseOwnedEntity is null) throw new InvalidOperationException("No enterprise owned entity found in the request.");

        Domain.Manager manager = await dbContext.Managers.FirstAsync(x => x.ManagerId == context.HttpContext.User.GetManagerId());

        if (enterpriseOwnedEntity.EnterpriseId is null) return await next(context);

        if (!manager.OwnsEnterprise(enterpriseOwnedEntity.EnterpriseId.Value))
        {
            context.HttpContext.Response.StatusCode = 403;
            return null;
        }

        return await next(context);
    }

}