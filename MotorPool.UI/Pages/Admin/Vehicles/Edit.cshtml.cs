using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Services;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.UI.Pages.Admin.Vehicles;

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

        return RedirectToPage("./List");
    }

}