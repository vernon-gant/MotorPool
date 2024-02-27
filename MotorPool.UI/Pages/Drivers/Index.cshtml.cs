using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Auth;
using MotorPool.Auth.Manager;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;

namespace MotorPool.UI.Pages.Drivers;

public class IndexModel(DriverService driverService, UserManager<ApplicationUser> userManager) : PageModel
{

    public IList<DriverViewModel> Drivers { get; set; } = default!;

    public async Task OnGetAsync()
    {
        var managerId = User.GetManagerId();
        Drivers = await driverService.GetByManagerIdAsync(managerId);
    }

}