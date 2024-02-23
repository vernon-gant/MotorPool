using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Enterprises
{
    public class DeleteModel : PageModel
    {
        private readonly MotorPool.Persistence.AppDbContext _context;

        public DeleteModel(MotorPool.Persistence.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enterprise Enterprise { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise = await _context.Enterprises.FirstOrDefaultAsync(m => m.EnterpriseId == id);

            if (enterprise == null)
            {
                return NotFound();
            }
            else
            {
                Enterprise = enterprise;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterprise = await _context.Enterprises.FindAsync(id);
            if (enterprise != null)
            {
                Enterprise = enterprise;
                _context.Enterprises.Remove(Enterprise);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
