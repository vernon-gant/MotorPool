using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Enterprises
{
    public class EditModel : PageModel
    {
        private readonly MotorPool.Persistence.AppDbContext _context;

        public EditModel(MotorPool.Persistence.AppDbContext context)
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

            var enterprise =  await _context.Enterprises.FirstOrDefaultAsync(m => m.EnterpriseId == id);
            if (enterprise == null)
            {
                return NotFound();
            }
            Enterprise = enterprise;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Enterprise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnterpriseExists(Enterprise.EnterpriseId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnterpriseExists(int id)
        {
            return _context.Enterprises.Any(e => e.EnterpriseId == id);
        }
    }
}
