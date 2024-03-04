using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleQueryService
{

    ValueTask<PagedViewModel<VehicleViewModel>> GetAllAsync(int managerId, PageOptions pageOptions);

    ValueTask<VehicleViewModel?> GetByIdAsync(int vehicleId);

}