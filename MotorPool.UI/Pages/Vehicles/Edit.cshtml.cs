using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;
using MotorPool.Services.Vehicles.ViewModels;
using MotorPool.UI.Pages.Admin.Vehicles;

namespace MotorPool.UI.Pages.Vehicles;

public class EditModel(VehicleService vehicleService, VehicleBrandService vehicleBrandService, IAuthorizationService authorizationService) : VehicleBrandsSelectListPageModel
{

    [BindProperty]
    public VehicleViewModel VehicleViewModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        PopulateVehicleBrandsDropDownList(vehicleBrandService);

        VehicleViewModel? foundVehicle = await vehicleService.GetById(id);

        if (foundVehicle == null) return NotFound();

        var authorizationResult = await authorizationService.AuthorizeAsync(User, foundVehicle, "IsManagerAccessible");

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