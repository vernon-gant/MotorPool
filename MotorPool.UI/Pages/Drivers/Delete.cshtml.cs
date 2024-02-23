using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Drivers
{
    public class DeleteModel : PageModel
    {
        private readonly MotorPool.Persistence.AppDbContext _context;

        public DeleteModel(MotorPool.Persistence.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Driver Driver { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FirstOrDefaultAsync(m => m.DriverId == id);

            if (driver == null)
            {
                return NotFound();
            }
            else
            {
                Driver = driver;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Drivers.FindAsync(id);
            if (driver != null)
            {
                Driver = driver;
                _context.Drivers.Remove(Driver);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
