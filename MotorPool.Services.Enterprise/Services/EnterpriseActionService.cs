using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services;

public interface EnterpriseActionService
{

    ValueTask<int> CreateAsync(EnterpriseDTO enterpriseDTO);

    ValueTask<int> UpdateAsync(EnterpriseViewModel enterpriseViewModel);

    ValueTask<int> DeleteAsync(int enterpriseId);

}