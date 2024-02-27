using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services;

public interface EnterpriseQueryService
{

    ValueTask<List<EnterpriseViewModel>> GetAllAsync();

    ValueTask<EnterpriseViewModel?> GetByIdAsync(int enterpriseId);

}