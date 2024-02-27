using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Persistence;
using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services.Concrete;

public class DefaultEnterpriseQueryService(AppDbContext dbContext, IMapper mapper) : EnterpriseQueryService
{

    public async ValueTask<List<EnterpriseViewModel>> GetAllAsync()
    {
        var rawEnterprises = await dbContext.Enterprises
                                            .AsNoTracking()
                                            .Include(enterprise => enterprise.ManagerLinks)
                                            .Include(enterprise => enterprise.Vehicles)
                                            .Include(enterprise => enterprise.Drivers)
                                            .Include(enterprise => enterprise.Vehicles)
                                            .Include(enterprise => enterprise.Drivers)
                                            .ToListAsync();

        return mapper.Map<List<EnterpriseViewModel>>(rawEnterprises);
    }

    public async ValueTask<EnterpriseViewModel?> GetByIdAsync(int enterpriseId)
    {
        var rawEnterprise = await dbContext.Enterprises
                                          .AsNoTracking()
                                          .Include(enterprise => enterprise.ManagerLinks)
                                          .Include(enterprise => enterprise.Vehicles)
                                          .Include(enterprise => enterprise.Drivers)
                                          .Include(enterprise => enterprise.Vehicles)
                                          .Include(enterprise => enterprise.Drivers)
                                          .FirstOrDefaultAsync(enterprise => enterprise.EnterpriseId == enterpriseId);

        return mapper.Map<EnterpriseViewModel?>(rawEnterprise);
    }

}