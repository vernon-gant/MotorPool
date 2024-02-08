using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleService
{

    Task EditVehicleAsync(VehicleDTO vehicleDto);

    ValueTask<List<VehicleViewModel>> GetVehiclesAsync();

    Task CreateVehicleAsync(VehicleDTO vehicleDto);

    ValueTask<VehicleViewModel?> GetVehicleById(int id);

}