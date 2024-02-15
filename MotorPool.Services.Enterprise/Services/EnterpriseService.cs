using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services;

public interface EnterpriseService
{

    ValueTask<List<EnterpriseViewModel>> GetAllAsync();

    ValueTask<List<EnterpriseViewModel>> GetByManagerAsync(int managerId);

}