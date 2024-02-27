using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.API.EndpointFilters;

public class VehicleExistsFilter(VehicleQueryService vehicleQueryService) : IEndpointFilter
{

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        int vehicleId = int.Parse(context.Arguments.FirstOrDefault(x => x.GetType().IsAssignableTo(typeof(int))).ToString());

        VehicleViewModel? vehicle = await vehicleQueryService.GetByIdAsync(vehicleId);

        if (vehicle is not null)
        {
            context.HttpContext.Items["Vehicle"] = vehicle;
            return await next(context);
        }

        context.HttpContext.Response.StatusCode = 404;

        return null;
    }

}