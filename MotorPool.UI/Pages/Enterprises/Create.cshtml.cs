using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Enterprises
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
            return Page();
        }

        [BindProperty]
        public Enterprise Enterprise { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enterprises.Add(Enterprise);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
