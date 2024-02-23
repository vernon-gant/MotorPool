using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleService
{

    Task EditAsync(VehicleDTO vehicleDto);

    ValueTask<List<VehicleViewModel>> GetAllAsync();

    Task CreateAsync(VehicleDTO vehicleDto);

    ValueTask<VehicleViewModel?> GetById(int id);

    ValueTask<List<VehicleViewModel>> GetAllByManagerIdAsync(int managerId);

}