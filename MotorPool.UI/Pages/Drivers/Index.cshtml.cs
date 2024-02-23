using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Auth;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;

namespace MotorPool.UI.Pages.Drivers;

public class IndexModel(DriverService driverService, UserManager<ApplicationUser> userManager) : PageModel
{

    public IList<DriverViewModel> Drivers { get;set; } = default!;

    public async Task OnGetAsync()
    {
        int managerId = int.Parse(User.Claims.First(c => c.Type == "managerId").Value);
        Drivers = await driverService.GetByManagerIdAsync(managerId);
    }
}