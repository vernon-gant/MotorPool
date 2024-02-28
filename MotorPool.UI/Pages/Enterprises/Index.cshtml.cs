using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Enterprise.Services;
using MotorPool.Services.Manager;

namespace MotorPool.UI.Pages.Enterprises;

public class IndexModel(EnterpriseQueryService enterpriseQueryService) : PageModel
{

    public IList<EnterpriseViewModel> Enterprises { get; set; } = new List<EnterpriseViewModel>();

    public async Task OnGetAsync()
    {
        List<EnterpriseViewModel> allEnterprises = await enterpriseQueryService.GetAllAsync();
        Enterprises = allEnterprises.ForManager(User.GetManagerId());
    }

}