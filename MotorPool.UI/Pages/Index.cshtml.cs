using Microsoft.AspNetCore.Mvc.RazorPages;

using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Enterprise.Services;
using MotorPool.Services.Manager;

namespace MotorPool.UI.Pages;

public class IndexModel(EnterpriseQueryService enterpriseQueryService) : PageModel
{

    public IList<SimpleEnterpriseViewModel> Enterprises { get; set; } = new List<SimpleEnterpriseViewModel>();

    public async Task OnGetAsync()
    {
        if (User.IsManager())
        {
            Enterprises = await enterpriseQueryService.GetAllSimpleAsync(User.GetManagerId());
        }
    }

}