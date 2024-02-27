using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleService
{

    ValueTask<VehicleViewModel> CreateAsync(VehicleDTO vehicleDto);

    ValueTask<VehicleViewModel?> GetById(int vehicleId);

    ValueTask EditAsync(VehicleDTO vehicleDto);

    ValueTask DeleteAsync(int vehicleId);

    ValueTask<List<VehicleViewModel>> GetAllAsync();

    ValueTask<List<VehicleViewModel>> GetAllByManagerIdAsync(int managerId);

}