using System.Reflection;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;

namespace MotorPool.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Vehicle>()
                    .HasData(
                        new Vehicle
                        {
                            VehicleId = 1,
                            VIN = "1HGBH41JXMN109186",
                            Manufacturer = "Toyota",
                            Model = "Corolla",
                            ManufactureYear = 2020,
                            ManufactureLand = "Japan",
                            Cost = 20000M,
                            Mileage = 15000M
                        },
                        new Vehicle
                        {
                            VehicleId = 2,
                            VIN = "2HGBH41JXMN109187",
                            Manufacturer = "Honda",
                            Model = "Civic",
                            ManufactureYear = 2019,
                            ManufactureLand = "Japan",
                            Cost = 18000M,
                            Mileage = 20000M
                        },
                        new Vehicle
                        {
                            VehicleId = 3,
                            VIN = "3CZRE4H56BG704113",
                            Manufacturer = "Ford",
                            Model = "Focus",
                            ManufactureYear = 2018,
                            ManufactureLand = "USA",
                            Cost = 17000M,
                            Mileage = 25000M
                        },
                        new Vehicle
                        {
                            VehicleId = 4,
                            VIN = "1HGCM82633A004352",
                            Manufacturer = "Chevrolet",
                            Model = "Impala",
                            ManufactureYear = 2021,
                            ManufactureLand = "USA",
                            Cost = 22000M,
                            Mileage = 10000M
                        },
                        new Vehicle
                        {
                            VehicleId = 5,
                            VIN = "19XFB2F59CE308872",
                            Manufacturer = "Nissan",
                            Model = "Altima",
                            ManufactureYear = 2022,
                            ManufactureLand = "Japan",
                            Cost = 24000M,
                            Mileage = 5000M
                        }
                    );
    }

}