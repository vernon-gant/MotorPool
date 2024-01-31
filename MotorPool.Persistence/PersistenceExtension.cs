using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MotorPool.Persistence;

public static class PersistenceExtension
{

    public static void AddPersistence(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<AppDbContext>(options => { options.UseSqlServer(connectionString); });
    }

}