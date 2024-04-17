using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services;

public interface EnterpriseActionService
{

    ValueTask<FullEnterpriseViewModel> CreateAsync(EnterpriseDTO enterpriseDTO, int managerId);

    ValueTask UpdateAsync(EnterpriseDTO enterpriseDTO, int enterpriseId);

    ValueTask DeleteAsync(int enterpriseId);

}