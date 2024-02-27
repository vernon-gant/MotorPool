using MotorPool.Services.Drivers.Models;

namespace MotorPool.Services.Drivers.Services;

public interface DriverQueryService
{

    ValueTask<List<DriverViewModel>> GetAllAsync();

    ValueTask<DriverViewModel> GetByIdAsync(int driverId);

}