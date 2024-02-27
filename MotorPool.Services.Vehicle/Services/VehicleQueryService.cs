using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleQueryService
{

    ValueTask<List<VehicleViewModel>> GetAllAsync();

    ValueTask<VehicleViewModel?> GetByIdAsync(int vehicleId);

}