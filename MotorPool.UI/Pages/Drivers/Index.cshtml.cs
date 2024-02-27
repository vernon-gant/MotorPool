using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.API.EndpointFilters;
using MotorPool.Auth;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;

namespace MotorPool.UI.Pages.Drivers;

public class IndexModel(DriverQueryService driverQueryService, UserManager<ApplicationUser> userManager) : PageModel
{

    public IList<DriverViewModel> Drivers { get; set; } = default!;

    public async Task OnGetAsync()
    {
        List<DriverViewModel> allDrivers = await driverQueryService.GetAllAsync();

        Drivers = allDrivers.Where(x => x.EnterpriseId == User.GetManagerId()).ToList();
    }

}