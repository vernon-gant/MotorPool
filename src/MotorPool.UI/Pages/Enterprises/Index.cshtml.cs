using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotorPool.Domain;
using MotorPool.Repository.Enterprise;
using MotorPool.Services.Manager;

namespace MotorPool.UI.Pages.Enterprises;

public class IndexModel(EnterpriseQueryRepository enterpriseQueryRepository, IMapper mapper) : PageModel
{

    public IList<SimpleEnterpriseViewModel> Enterprises { get; set; } = new List<SimpleEnterpriseViewModel>();

    public async Task OnGetAsync()
    {
        List<Enterprise> managerEnterprises = await enterpriseQueryRepository.GetAllAsync(User.GetManagerId());

        Enterprises = mapper.Map<List<SimpleEnterpriseViewModel>>(managerEnterprises);
    }

}