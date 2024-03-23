using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Geo.Models;
using MotorPool.Services.Geo.Services;

namespace MotorPool.UI.Pages.Vehicles;

public class MapModel(TripQueryService tripQueryService) : PageModel
{

    [BindProperty(SupportsGet = true)]
    public int[] SelectedTrips { get; set; } = Array.Empty<int>();

    [BindProperty(SupportsGet = true)]
    public int VehicleId { get; set; }

    public IEnumerable<(TripViewModel, List<GeoPointViewModel>)> TripsWithRoutes { get; set; } = default!;

    public async Task OnGetAsync()
    {
        TripsWithRoutes = await tripQueryService.GetTripsWithRoutes(VehicleId, SelectedTrips);
    }

}