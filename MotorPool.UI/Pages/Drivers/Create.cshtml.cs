using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Drivers
{
    public class CreateModel : PageModel
    {
        private readonly MotorPool.Persistence.AppDbContext _context;

        public CreateModel(MotorPool.Persistence.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ActiveVehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "ManufactureLand");
        ViewData["EnterpriseId"] = new SelectList(_context.Enterprises, "EnterpriseId", "City");
            return Page();
        }

        [BindProperty]
        public Driver Driver { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Drivers.Add(Driver);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
