using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Brands;

[AllowAnonymous]
public class IndexModel : PageModel
{

    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public IList<VehicleBrand> VehicleBrand { get; set; } = default!;

    public async Task OnGetAsync()
    {
        VehicleBrand = await _context.VehicleBrands.ToListAsync();
    }

}