using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleQueryService
{

    ValueTask<List<VehicleViewModel>> GetAllAsync(VehicleQueryOptions? queryOptions = null);

    ValueTask<PagedViewModel<VehicleViewModel>> GetAllAsync(PageOptions pageOptions, VehicleQueryOptions? queryOptions = null);

    ValueTask<VehicleViewModel?> GetByIdAsync(int vehicleId);

}