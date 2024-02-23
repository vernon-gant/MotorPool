using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Enterprises
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Enterprise> Enterprise { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Enterprise = await _context.Enterprises.ToListAsync();
        }
    }
}
