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
        IQueryable<Vehicle> vehiclesWithBrandQuery = _context.Vehicles.Include(vehicle => vehicle.VehicleBrand);

        if (!vehicleBrandId.HasValue)
        {
            Vehicles = await vehiclesWithBrandQuery.ToListAsync();
            return;
        }

        Vehicles = await vehiclesWithBrandQuery.Where(vehicle => vehicle.VehicleBrandId == vehicleBrandId).ToListAsync();
    }

}