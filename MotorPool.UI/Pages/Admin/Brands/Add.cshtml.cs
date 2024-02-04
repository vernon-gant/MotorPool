using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Admin.Brands
{
    public class AddModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VehicleBrand VehicleBrand { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VehicleBrands.Add(VehicleBrand);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
