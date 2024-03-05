using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Drivers.Services;
using MotorPool.Services.Manager;
using MotorPool.Services.Utils;
using MotorPool.UI.Pages.Shared;

namespace MotorPool.UI.Pages.Drivers;

public class IndexModel(DriverQueryService driverQueryService) : PagedModel
{

    public IList<DriverViewModel> Drivers { get; set; } = default!;

    public async Task OnGetAsync(int? currentPage)
    {
        CurrentPage = currentPage ?? 1;

        PagedViewModel<DriverViewModel> pagedViewModel = await driverQueryService.GetAllAsync(User.GetManagerId(), new ()
        {
            ElementsPerPage = ELEMENTS_PER_PAGE,
            PageNumber = CurrentPage
        });

        TotalPages = pagedViewModel.TotalPages;
        Drivers = pagedViewModel.Elements;
    }

}