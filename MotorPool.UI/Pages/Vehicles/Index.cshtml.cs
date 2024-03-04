using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Manager;
using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class IndexModel(VehicleQueryService vehicleQueryService) : PageModel
{

    public IList<VehicleViewModel> Vehicles { get; set; } = default!;

    public async Task OnGetAsync(int? vehicleBrandId)
    {
        PagedViewModel<VehicleViewModel> allVehicles = await vehicleQueryService.GetAllAsync(User.GetManagerId(), new PageOptions()
        {
            ElementsPerPage = 1,
            PageNumber = 2
        });

        if (!vehicleBrandId.HasValue)
        {
            Vehicles = allVehicles.Elements;

            return;
        }

        Vehicles = allVehicles.Elements.Where(vehicle => vehicle.VehicleBrandId == vehicleBrandId).ToList();
    }

}