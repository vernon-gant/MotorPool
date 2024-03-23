using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Geo.Models;
using MotorPool.Services.Geo.Services;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.UI.Pages.Vehicles;

public class DetailsModel(TripQueryService tripQueryService) : PageModel
{

    [BindProperty(SupportsGet = true)]
    public DateTime? StartDate { get; set; }

    [BindProperty(SupportsGet = true)]
    public DateTime? EndDate { get; set; }

    public VehicleViewModel Vehicle { get; set; } = default!;

    public IEnumerable<TripViewModel> VehicleTrips { get; set; } = new List<TripViewModel>();

    public async Task OnGetAsync(int vehicleId)
    {
        Vehicle = HttpContext.Items["Vehicle"] as VehicleViewModel ?? throw new InvalidOperationException("Vehicle not found");

        if (StartDate is null && EndDate is null)
        {
            VehicleTrips = Enumerable.Empty<TripViewModel>();
            return;
        }

        DateTime unspecifiedStart = DateTime.SpecifyKind(StartDate ?? DateTime.Now.AddMonths(-1),DateTimeKind.Unspecified);

        DateTime unspecifiedEnd = DateTime.SpecifyKind(EndDate ?? DateTime.Now,DateTimeKind.Unspecified);

        VehicleTrips = await tripQueryService.GetVehicleTrips(vehicleId, unspecifiedStart, unspecifiedEnd);
    }

    public bool NoTripsFound() => StartDate != null && EndDate != null && VehicleTrips.Any();

}