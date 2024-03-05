using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Persistence;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Manager;

namespace MotorPool.Services.Enterprise.Services.Concrete;

public class DefaultEnterpriseQueryService(AppDbContext dbContext, IMapper mapper) : EnterpriseQueryService
{

    public async ValueTask<List<FullEnterpriseViewModel>> GetAllAsync(int managerId) =>
        await FullRelationEnterpriseQuery().ForManager(managerId).Select(enterprise => mapper.Map<FullEnterpriseViewModel>(enterprise)).ToListAsync();

    public async ValueTask<List<SimpleEnterpriseViewModel>> GetAllSimpleAsync(int managerId) =>
        await BaseEnterpriseQuery().ForManager(managerId).Select(enterprise => mapper.Map<SimpleEnterpriseViewModel>(enterprise)).ToListAsync();

    public async ValueTask<FullEnterpriseViewModel?> GetByIdAsync(int enterpriseId) => await FullRelationEnterpriseQuery()
                                                                                             .Select(enterprise => mapper.Map<FullEnterpriseViewModel>(enterprise))
                                                                                             .FirstOrDefaultAsync(enterprise => enterprise.EnterpriseId == enterpriseId);

    private IQueryable<Domain.Enterprise> BaseEnterpriseQuery() => dbContext.Enterprises.AsNoTracking().Include(enterprise => enterprise.ManagerLinks);

    private IQueryable<Domain.Enterprise> FullRelationEnterpriseQuery() => BaseEnterpriseQuery()
                                                                           .Include(enterprise => enterprise.Vehicles)
                                                                           .Include(enterprise => enterprise.Drivers);

}