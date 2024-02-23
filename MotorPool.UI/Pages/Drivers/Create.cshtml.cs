using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Drivers.Models;

namespace MotorPool.UI.Pages.Drivers;

public class CreateModel : PageModel
{

    [BindProperty]
    public DriverDTO Driver { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }


    public async Task<IActionResult> OnPostAsync()
    {
        return Page();
    }

}