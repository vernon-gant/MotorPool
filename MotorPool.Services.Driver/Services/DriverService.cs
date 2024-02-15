using MotorPool.Services.Drivers.Models;

namespace MotorPool.Services.Drivers.Services;

public interface DriverService
{

    ValueTask<List<DriverViewModel>> GetAllAsync();

    ValueTask<List<DriverViewModel>> GetByManagerAsync(int managerId);

}