using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Manager;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class IndexModel(VehicleQueryService vehicleQueryService) : PageModel
{

    public IList<VehicleViewModel> Vehicles { get; set; } = default!;

    public async Task OnGetAsync(int? vehicleBrandId)
    {
        List<VehicleViewModel> allVehicles = await vehicleQueryService.GetAllAsync();

        if (!vehicleBrandId.HasValue)
        {
            Vehicles = allVehicles;
            return;
        }

        Vehicles = allVehicles.Where(vehicle => vehicle.VehicleBrandId == vehicleBrandId).ToList();
    }

}