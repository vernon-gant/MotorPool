using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class CreateModel(VehicleActionService vehicleActionService, VehicleBrandService vehicleBrandService) : VehicleBrandsSelectListPageModel
{

    [BindProperty]
    public VehicleDTO VehicleDto { get; set; } = default!;

    public async Task<IActionResult> OnGet()
    {
        await PopulateVehicleBrandsDropDownList(vehicleBrandService);
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await vehicleActionService.CreateAsync(VehicleDto);

        return RedirectToPage("./Index");
    }

}