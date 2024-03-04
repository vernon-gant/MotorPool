using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Utils;

namespace MotorPool.Services.Drivers.Services;

public interface DriverQueryService
{

    ValueTask<PagedViewModel<DriverViewModel>> GetAllAsync(int managerId, PageOptions pageOptions);

    ValueTask<DriverViewModel> GetByIdAsync(int driverId);

}