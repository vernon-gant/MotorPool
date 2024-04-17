using Microsoft.AspNetCore.Mvc;

using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class EditModel(VehicleActionService vehicleActionService, VehicleBrandService vehicleBrandService) : VehicleBrandsSelectListPageModel
{

    [BindProperty]
    public VehicleViewModel VehicleViewModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int vehicleId)
    {
        await PopulateVehicleBrandsDropDownList(vehicleBrandService);

        VehicleViewModel = HttpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await vehicleActionService.UpdateAsync(VehicleViewModel, VehicleViewModel.VehicleId);

        return RedirectToPage("./Index");
    }

}