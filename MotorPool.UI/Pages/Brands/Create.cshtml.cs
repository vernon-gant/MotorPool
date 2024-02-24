using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Brands;

public class CreateModel(AppDbContext context) : PageModel
{

    [BindProperty]
    public VehicleBrand VehicleBrand { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        context.VehicleBrands.Add(VehicleBrand);
        await context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }

}