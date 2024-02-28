using Microsoft.EntityFrameworkCore;

using MotorPool.Abstractions;
using MotorPool.Persistence;
using MotorPool.Services.Manager;

namespace MotorPool.API.EndpointFilters;

public class EnterpriseIsManagerAccessibleFilter(AppDbContext dbContext) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        EnterpriseOwned? enterpriseOwnedEntity = context.Arguments.FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(EnterpriseOwned))) as EnterpriseOwned;

        if (enterpriseOwnedEntity is null) throw new InvalidOperationException("No enterprise owned entity found in the request.");

        Domain.Manager manager = await dbContext.Managers.Include(manager => manager.EnterpriseLinks).FirstAsync(x => x.ManagerId == context.HttpContext.User.GetManagerId());

        if (enterpriseOwnedEntity.EnterpriseId is null) return await next(context);

        if (!manager.OwnsEnterprise(enterpriseOwnedEntity.EnterpriseId.Value))
        {
            context.HttpContext.Response.StatusCode = 403;
            await context.HttpContext.Response.WriteAsJsonAsync(new { Message = "You are not allowed to access this enterprise." });
            return null;
        }

        return await next(context);
    }

}