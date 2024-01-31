using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Admin.Vehicles;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<Vehicle> Vehicle { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Vehicle = await _context.Vehicles.ToListAsync();
    }
}