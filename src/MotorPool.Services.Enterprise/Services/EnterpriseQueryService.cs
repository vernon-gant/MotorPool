using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services;

public interface EnterpriseQueryService
{

    ValueTask<List<FullEnterpriseViewModel>> GetAllAsync(int managerId);

    ValueTask<List<SimpleEnterpriseViewModel>> GetAllSimpleAsync(int managerId);

    ValueTask<FullEnterpriseViewModel?> GetByIdAsync(int enterpriseId);

}