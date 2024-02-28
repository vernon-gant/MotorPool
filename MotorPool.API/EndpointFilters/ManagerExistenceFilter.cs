using MotorPool.Persistence;
using MotorPool.Services.Manager;

namespace MotorPool.API.EndpointFilters;

public class ManagerExistenceFilter(AppDbContext dbContext) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        int managerId = context.HttpContext.User.GetManagerId();
        Domain.Manager? manager = await dbContext.Managers.FindAsync(managerId);

        if (manager is not null) return await next(context);

        context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
        return null;
    }

}