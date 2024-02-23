using MotorPool.Services.VehicleBrand.Models;
using MotorPool.Services.VehicleBrand.ViewModels;

namespace MotorPool.Services.VehicleBrand.Services;

public interface VehicleBrandService
{

    ValueTask<List<VehicleBrandSignatureWithId>> GetVehicleBrandsWithIdAsync();

    ValueTask<List<VehicleBrandViewModel>> GetAllAsync();

}