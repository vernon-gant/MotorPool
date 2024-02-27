using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Auth;
using MotorPool.Auth.EndpointFilters;
using MotorPool.Auth.Manager;
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
        List<VehicleViewModel> managerVehicles = allVehicles.ForManager(User.GetManagerId());

        if (!vehicleBrandId.HasValue)
        {
            Vehicles = managerVehicles;
            return;
        }

        Vehicles = managerVehicles.Where(vehicle => vehicle.VehicleBrandId == vehicleBrandId).ToList();
    }

}