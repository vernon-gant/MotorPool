using Microsoft.EntityFrameworkCore;

using MotorPool.Abstractions;
using MotorPool.Persistence;

namespace MotorPool.Auth.Manager;

public class EnterpriseInResourceIsManagerAccessibleFilter(AppDbContext dbContext) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        EnterpriseOwnedEntity? enterpriseOwnedEntity = context.HttpContext.Request.RouteValues.Values.FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(EnterpriseOwnedEntity))) as EnterpriseOwnedEntity;

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