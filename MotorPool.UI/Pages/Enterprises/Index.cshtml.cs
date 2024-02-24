using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Auth;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Enterprise.Services;

namespace MotorPool.UI.Pages.Enterprises;

public class IndexModel(EnterpriseService enterpriseService) : PageModel
{

    public IList<EnterpriseViewModel> Enterprises { get; set; } = new List<EnterpriseViewModel>();

    public async Task OnGetAsync()
    {
        var managerId = User.GetManagerId();
        Enterprises = await enterpriseService.GetAllByManagerIdAsync(managerId);
    }

}