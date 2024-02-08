using MotorPool.Services.VehicleBrand.ViewModels;

namespace MotorPool.Services.VehicleBrand.Services;

public interface VehicleBrandService
{

    ValueTask<List<VehicleBrandSignatureWithId>> GetVehicleBrandsWithId();

    ValueTask<List<VehicleBrandViewModel>> GetVehicles();

}