using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Auth;
using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Manager;
using MotorPool.Services.Utils;

namespace MotorPool.UI.Pages.Drivers;

public class IndexModel(DriverQueryService driverQueryService, UserManager<ApplicationUser> userManager) : PageModel
{

    public IList<DriverViewModel> Drivers { get; set; } = default!;

    public async Task OnGetAsync()
    {
        PagedViewModel<DriverViewModel> pagedViewModel = await driverQueryService.GetAllAsync(User.GetManagerId(), new PageOptions()
        {
            ElementsPerPage = 1,
            PageNumber = 0
        });

        Drivers = pagedViewModel.Elements.Where(x => x.EnterpriseId == User.GetManagerId()).ToList();
    }

}