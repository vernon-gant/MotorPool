using AutoMapper;

using MotorPool.Persistence;
using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services.Concrete;

public class DefaultEnterpriseActionService(AppDbContext dbContext, IMapper mapper) : EnterpriseActionService
{

    public async ValueTask<int> CreateAsync(EnterpriseDTO enterpriseDTO)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<int> UpdateAsync(EnterpriseViewModel enterpriseViewModel)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<int> DeleteAsync(int enterpriseId)
    {
        throw new NotImplementedException();
    }

}