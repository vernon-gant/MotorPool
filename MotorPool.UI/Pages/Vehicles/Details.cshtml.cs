using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class DetailsModel(VehicleService vehicleService, IAuthorizationService authorizationService) : PageModel
{

    public VehicleViewModel VehicleViewModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        VehicleViewModel? foundVehicle = await vehicleService.GetById(id.Value);

        if (foundVehicle == null) return NotFound();

        AuthorizationResult authorizationResult = await authorizationService.AuthorizeAsync(User, foundVehicle, "IsManagerAccessible");

        if (!authorizationResult.Succeeded) return Forbid();

        VehicleViewModel = foundVehicle;

        return Page();
    }

}