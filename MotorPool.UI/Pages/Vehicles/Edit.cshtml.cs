using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class EditModel(VehicleService vehicleService, VehicleBrandService vehicleBrandService, IAuthorizationService authorizationService) : VehicleBrandsSelectListPageModel
{

    [BindProperty]
    public VehicleViewModel VehicleViewModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        await PopulateVehicleBrandsDropDownList(vehicleBrandService);

        var foundVehicle = await vehicleService.GetById(id);

        if (foundVehicle == null) return NotFound();

        var authorizationResult = await authorizationService.AuthorizeAsync(User, foundVehicle, "IsManagerAccessible");

        if (!authorizationResult.Succeeded) return Forbid();

        VehicleViewModel = foundVehicle;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await vehicleService.EditAsync(VehicleViewModel);

        return RedirectToPage("./Index");
    }

}