using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class DeleteModel(VehicleActionService vehicleActionService) : PageModel
{

    [BindProperty]
    public VehicleViewModel Vehicle { get; set; } = default!;

    public Task<IActionResult> OnGetAsync(int vehicleId)
    {
        Vehicle = HttpContext.Items["Vehicle"] as VehicleViewModel ?? throw new ArgumentNullException(nameof(Vehicle));

        return Task.FromResult<IActionResult>(Page());
    }

    public async Task<IActionResult> OnPostAsync(int vehicleId)
    {
        await vehicleActionService.DeleteAsync(vehicleId);

        string returnUrl = HttpContext.Session.GetString("VehicleIndexReturnUrl") ?? "/Vehicles/Index";

        return Redirect(returnUrl);
    }

}