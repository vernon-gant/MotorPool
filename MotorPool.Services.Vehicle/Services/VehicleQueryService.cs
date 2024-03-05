using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleQueryService
{
    ValueTask<List<VehicleViewModel>> GetAllAsync(int managerId);

    ValueTask<PagedViewModel<VehicleViewModel>> GetAllAsync(int managerId, PageOptions pageOptions, int? vehicleBrandId = null);

    ValueTask<VehicleViewModel?> GetByIdAsync(int vehicleId);

}