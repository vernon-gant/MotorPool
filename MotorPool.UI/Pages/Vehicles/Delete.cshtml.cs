using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Vehicles;

public class DeleteModel(AppDbContext context) : PageModel
{

    [BindProperty]
    public Driver Driver { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var driver = await context.Drivers.FirstOrDefaultAsync(m => m.DriverId == id);

        if (driver == null)
        {
            return NotFound();
        }

        Driver = driver;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null) return NotFound();

        var driver = await context.Drivers.FindAsync(id);

        if (driver != null)
        {
            Driver = driver;
            context.Drivers.Remove(Driver);
            await context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }

}