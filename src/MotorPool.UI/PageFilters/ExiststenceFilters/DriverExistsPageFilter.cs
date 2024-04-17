using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;

namespace MotorPool.UI.PageFilters;

public class DriverExistsPageFilter(DriverQueryService driverQueryService) : IAsyncPageFilter
{

    public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        return Task.CompletedTask;
    }

    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
    {
        string? driverIdString = context.RouteData.Values["driverId"]?.ToString();

        if (driverIdString == null)
        {
            await next();
            return;
        }

        int driverId = int.Parse(driverIdString);

        DriverViewModel? driver = await driverQueryService.GetByIdAsync(driverId);

        if (driver == null)
        {
            context.Result = new RedirectToPageResult("/Error/NotFound");

            return;
        }

        context.HttpContext.Items["Driver"] = driver;
        await next();
    }

}