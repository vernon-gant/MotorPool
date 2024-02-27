using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class EditModel(VehicleActionService vehicleActionService, VehicleQueryService vehicleQueryService, VehicleBrandService vehicleBrandService) : VehicleBrandsSelectListPageModel
{

    [BindProperty]
    public VehicleViewModel VehicleViewModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        await PopulateVehicleBrandsDropDownList(vehicleBrandService);

        VehicleViewModel? foundVehicle = await vehicleQueryService.GetById(id);

        if (foundVehicle == null) return NotFound();

        VehicleViewModel = foundVehicle;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await vehicleActionService.UpdateAsync(VehicleViewModel);

        return RedirectToPage("./Index");
    }

}