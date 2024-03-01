using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.DatabaseSeeder;

public interface EnterpriseRepository
{

    ValueTask<List<Enterprise>> GetEnterprisesAsync();

}

public class EfDatabaseRepository(AppDbContext dbContext) : EnterpriseRepository
{

    public async ValueTask<List<Enterprise>> GetEnterprisesAsync() => await dbContext.Enterprises.ToListAsync();

}