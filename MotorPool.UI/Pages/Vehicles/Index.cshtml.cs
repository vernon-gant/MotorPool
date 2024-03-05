using MotorPool.Services.Manager;
using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;
using MotorPool.UI.Pages.Shared;

namespace MotorPool.UI.Pages.Vehicles;

public class IndexModel(VehicleQueryService vehicleQueryService) : PagedModel
{

    public IList<VehicleViewModel> Vehicles { get; set; } = default!;

    public async Task OnGetAsync(int? vehicleBrandId, int? currentPage)
    {
        CurrentPage = currentPage ?? 1;

        PagedViewModel<VehicleViewModel> allVehicles = await vehicleQueryService.GetAllAsync(User.GetManagerId(), new PageOptions
        {
            ElementsPerPage = ELEMENTS_PER_PAGE,
            PageNumber = CurrentPage
        });

        TotalPages = allVehicles.TotalPages;

        if (!vehicleBrandId.HasValue)
        {
            Vehicles = allVehicles.Elements;
            return;
        }

        Vehicles = allVehicles.Elements.Where(vehicle => vehicle.VehicleBrandId == vehicleBrandId).ToList();
    }

}