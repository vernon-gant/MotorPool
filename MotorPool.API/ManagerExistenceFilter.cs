using System.Security.Claims;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.API;

public class ManagerExistenceFilter(AppDbContext dbContext) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        string managerId = context.HttpContext.User.FindFirstValue("ManagerId")!;
        Manager? manager = await dbContext.Managers.FindAsync(int.Parse(managerId));

        if (manager is not null) return await next(context);

        context.HttpContext.Response.StatusCode = 403;
        return null;
    }

}