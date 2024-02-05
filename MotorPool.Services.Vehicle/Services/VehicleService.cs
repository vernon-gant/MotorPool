using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles.Services;

public interface VehicleService
{

    Task EditVehicleAsync(VehicleFormViewModel vehicleViewModel);

}