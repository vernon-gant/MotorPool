using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Admin.Vehicles;

public class ListModel : PageModel
{

    private readonly AppDbContext _context;

    public ListModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Vehicle> Vehicles { get; set; } = default!;

    public async Task OnGetAsync(int? vehicleBrandId)
    {
        if (!vehicleBrandId.HasValue)
        {
            Vehicles = await _context.Vehicles.ToListAsync();
            return;
        }

        Vehicles = await _context.Vehicles.Where(vehicle => vehicle.VehicleBrandId == vehicleBrandId).ToListAsync();
    }

}