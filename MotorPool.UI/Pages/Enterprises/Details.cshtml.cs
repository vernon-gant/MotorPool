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
    public class DetailsModel : PageModel
    {
        private readonly MotorPool.Persistence.AppDbContext _context;

        public DetailsModel(MotorPool.Persistence.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
