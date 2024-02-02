using System.Reflection;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;

namespace MotorPool.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<VehicleBrand> VehicleBrands { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<VehicleBrand>().HasData(
            new VehicleBrand { VehicleBrandId = 1, CompanyName = "Toyota", ModelName = "Corolla", Type = VehicleType.PassengerCar, FuelTankCapacityLiters = 50, PayloadCapacityKg = 450, NumberOfSeats = 5, ReleaseYear = 2020 },
            new VehicleBrand { VehicleBrandId = 2, CompanyName = "Volvo", ModelName = "B7R", Type = VehicleType.Bus, FuelTankCapacityLiters = 300, PayloadCapacityKg = 7500, NumberOfSeats = 50, ReleaseYear = 2019 },
            new VehicleBrand { VehicleBrandId = 3, CompanyName = "Scania", ModelName = "P Series", Type = VehicleType.Truck, FuelTankCapacityLiters = 400, PayloadCapacityKg = 15000, NumberOfSeats = 3, ReleaseYear = 2018 },
            new VehicleBrand { VehicleBrandId = 4, CompanyName = "Mercedes-Benz", ModelName = "Citaro", Type = VehicleType.Bus, FuelTankCapacityLiters = 275, PayloadCapacityKg = 18000, NumberOfSeats = 45, ReleaseYear = 2021 },
            new VehicleBrand { VehicleBrandId = 5, CompanyName = "Ford", ModelName = "Transit", Type = VehicleType.Truck, FuelTankCapacityLiters = 80, PayloadCapacityKg = 1200, NumberOfSeats = 3, ReleaseYear = 2022 }
        );

        modelBuilder.Entity<Vehicle>().HasData(
            new Vehicle { VehicleId = 1, MotorVIN = "1HGBH41JXMN109186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 20000M, Mileage = 15000M, VehicleBrandId = 1 },
            new Vehicle { VehicleId = 2, MotorVIN = "2VOLVOB7R0MN10918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 100000M, Mileage = 50000M, VehicleBrandId = 2 },
            new Vehicle { VehicleId = 3, MotorVIN = "3SCANPSE0MN109187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 120000M, Mileage = 20000M, VehicleBrandId = 3 },
            new Vehicle { VehicleId = 4, MotorVIN = "4MBNZCTR0MN109186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 110000M, Mileage = 30000M, VehicleBrandId = 4 },
            new Vehicle { VehicleId = 5, MotorVIN = "5FORDTRN0MN109185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 30000M, Mileage = 10000M, VehicleBrandId = 5 },
            new Vehicle { VehicleId = 6, MotorVIN = "6HGBH41JXMN209186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 22000M, Mileage = 12000M, VehicleBrandId = 1 },
            new Vehicle { VehicleId = 7, MotorVIN = "7VOLVOB7R1MN20918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 105000M, Mileage = 55000M, VehicleBrandId = 2 },
            new Vehicle { VehicleId = 8, MotorVIN = "8SCANPSE1MN209187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 125000M, Mileage = 22000M, VehicleBrandId = 3 },
            new Vehicle { VehicleId = 9, MotorVIN = "9MBNZCTR1MN209186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 115000M, Mileage = 32000M, VehicleBrandId = 4 },
            new Vehicle { VehicleId = 10, MotorVIN = "0FORDTRN1MN209185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 32000M, Mileage = 11000M, VehicleBrandId = 5 }
        );

    }

}