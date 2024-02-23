using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Services;
using MotorPool.Services.Vehicles.ViewModels;
using MotorPool.UI.Pages.Admin.Vehicles;

namespace MotorPool.UI.Pages.Vehicles;

public class EditModel(VehicleService vehicleService, VehicleBrandService vehicleBrandService, IMapper mapper) : VehicleBrandsSelectListPageModel
{

    [BindProperty]
    public VehicleDTO VehicleDto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        PopulateVehicleBrandsDropDownList(vehicleBrandService);

        VehicleDTO? foundVehicle = await vehicleService.GetVehicleById(id);

        if (foundVehicle == null) return NotFound();

        VehicleDto = foundVehicle;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await vehicleService.EditVehicleAsync(VehicleDto);

        return RedirectToPage("./Index");
    }

}