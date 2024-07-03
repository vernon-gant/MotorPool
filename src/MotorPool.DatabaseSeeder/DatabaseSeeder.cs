using System.Collections.Concurrent;
using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.DatabaseSeeder;

public class DatabaseSeeder(VehicleDriversGenerator dataGenerator, AppDbContext dbContext)
{
    public void Seed(SeedingOptions options)
    {

    }
}