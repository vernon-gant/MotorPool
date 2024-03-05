using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.PageFilters;

public class VehicleExistsPageFilter(VehicleQueryService vehicleQueryService) : IAsyncPageFilter
{

    public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        return Task.CompletedTask;
    }

    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        string? vehicleIdString = context.RouteData.Values["vehicleId"]?.ToString();

        if (vehicleIdString == null)
        {
            await next();
            return;
        }

        int vehicleId = int.Parse(vehicleIdString);

        VehicleViewModel? vehicle = await vehicleQueryService.GetByIdAsync(vehicleId);

        if (vehicle == null)
        {
            context.Result = new RedirectToPageResult("/Error/NotFound");

            return;
        }

        context.HttpContext.Items["Vehicle"] = vehicle;
        await next();
    }

}