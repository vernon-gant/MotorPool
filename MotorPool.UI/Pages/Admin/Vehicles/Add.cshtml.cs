using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Vehicles.Services;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.UI.Pages.Admin.Vehicles;

public class AddVehicleModel(VehicleService vehicleService) : PageModel
{

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public VehicleDTO VehicleDto { get; set; } = default!;


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await vehicleService.CreateVehicleAsync(VehicleDto);

        return RedirectToPage("./Index");
    }
}