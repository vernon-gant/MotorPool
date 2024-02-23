using AutoMapper;

using Microsoft.EntityFrameworkCore;

using MotorPool.Persistence;
using MotorPool.Services.Enterprise.Models;

namespace MotorPool.Services.Enterprise.Services.Concrete;

public class DefaultEnterpriseService(AppDbContext dbContext, IMapper mapper) : EnterpriseService
{

    public async ValueTask<List<EnterpriseViewModel>> GetAllAsync()
    {
        List<Domain.Enterprise> rawEnterprises = await dbContext.Enterprises
                                                                .AsNoTracking()
                                                                .Include(enterprise => enterprise.Vehicles)
                                                                .Include(enterprise => enterprise.Drivers)
                                                                .ToListAsync();

        return mapper.Map<List<EnterpriseViewModel>>(rawEnterprises);
    }

    public async ValueTask<List<EnterpriseViewModel>> GetByManagerIdAsync(int managerId)
    {
        List<Domain.Enterprise> rawEnterprises = await dbContext.Enterprises
                                                                .AsNoTracking()
                                                                .Include(enterprise => enterprise.ManagerLinks)
                                                                .Include(enterprise => enterprise.Vehicles)
                                                                .Include(enterprise => enterprise.Drivers)
                                                                .Where(enterprise => enterprise.ManagerLinks.Any(manager => manager.ManagerId == managerId))
                                                                .ToListAsync();

        return mapper.Map<List<EnterpriseViewModel>>(rawEnterprises);
    }

}