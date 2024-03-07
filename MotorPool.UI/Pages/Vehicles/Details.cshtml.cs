using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Vehicles.Models;

namespace MotorPool.UI.Pages.Vehicles;

public class DetailsModel : PageModel
{

    public VehicleViewModel Vehicle { get; set; } = default!;

    public Task<IActionResult> OnGetAsync(int vehicleId)
    {
        Vehicle = HttpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException("Vehicle not found");

        return Task.FromResult<IActionResult>(Page());
    }

}