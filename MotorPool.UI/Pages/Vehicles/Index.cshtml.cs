using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using MotorPool.Auth;
using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class IndexModel(VehicleService vehicleService) : PageModel
{

    public IList<VehicleViewModel> Vehicles { get; set; } = default!;

    public async Task OnGetAsync(int? vehicleBrandId)
    {
        int managerId = User.GetManagerId();
        List<VehicleViewModel> managerVehicles = await vehicleService.GetAllByManagerIdAsync(managerId);

        if (!vehicleBrandId.HasValue)
        {
            Vehicles = managerVehicles;
            return;
        }

        Vehicles = managerVehicles.Where(vehicle => vehicle.VehicleBrandId == vehicleBrandId).ToList();
    }

}