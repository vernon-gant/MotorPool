using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleActionService
{

    ValueTask<VehicleViewModel> CreateAsync(VehicleDTO vehicleDto);

    ValueTask UpdateAsync(VehicleDTO vehicleDto, int vehicleId);

    ValueTask DeleteAsync(int vehicleId);

}