using System.Reflection;

using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;

namespace MotorPool.Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<VehicleBrand> VehicleBrands { get; set; }

    public DbSet<Driver> Drivers { get; set; }

    public DbSet<Enterprise> Enterprises { get; set; }

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
            new Vehicle { VehicleId = 10, MotorVIN = "0FORDTRN1MN209185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 32000M, Mileage = 11000M, VehicleBrandId = 5 },
            new Vehicle { VehicleId = 11, MotorVIN = "1HGBH41JXMN309186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 23000M, Mileage = 13000M, VehicleBrandId = 1 },
            new Vehicle { VehicleId = 12, MotorVIN = "2VOLVOB7R2MN30918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 110000M, Mileage = 60000M, VehicleBrandId = 2 },
            new Vehicle { VehicleId = 13, MotorVIN = "3SCANPSE2MN309187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 130000M, Mileage = 24000M, VehicleBrandId = 3 },
            new Vehicle { VehicleId = 14, MotorVIN = "4MBNZCTR2MN309186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 120000M, Mileage = 33000M, VehicleBrandId = 4 },
            new Vehicle { VehicleId = 15, MotorVIN = "5FORDTRN2MN309185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 34000M, Mileage = 12000M, VehicleBrandId = 5 },
            new Vehicle { VehicleId = 16, MotorVIN = "6HGBH41JXMN409186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 24000M, Mileage = 14000M, VehicleBrandId = 1 },
            new Vehicle { VehicleId = 17, MotorVIN = "7VOLVOB7R3MN40918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 115000M, Mileage = 65000M, VehicleBrandId = 2 },
            new Vehicle { VehicleId = 18, MotorVIN = "8SCANPSE3MN409187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 135000M, Mileage = 26000M, VehicleBrandId = 3 },
            new Vehicle { VehicleId = 19, MotorVIN = "9MBNZCTR3MN409186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 125000M, Mileage = 34000M, VehicleBrandId = 4 },
            new Vehicle { VehicleId = 20, MotorVIN = "0FORDTRN3MN409185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 36000M, Mileage = 13000M, VehicleBrandId = 5 }
        );

        modelBuilder.Entity<Driver>().HasData(
            new Driver { DriverId = 1, FirstName = "John", LastName = "Doe", Salary = 2000M},
            new Driver { DriverId = 2, FirstName = "Jane", LastName = "Doe", Salary = 2500M},
            new Driver { DriverId = 3, FirstName = "Jack", LastName = "Doe", Salary = 3000M},
            new Driver { DriverId = 4, FirstName = "Jill", LastName = "Doe", Salary = 3500M},
            new Driver { DriverId = 5, FirstName = "Jim", LastName = "Doe", Salary = 4000M},
            new Driver { DriverId = 6, FirstName = "Jenny", LastName = "Doe", Salary = 4500M},
            new Driver { DriverId = 7, FirstName = "Jasper", LastName = "Doe", Salary = 5000M},
            new Driver { DriverId = 8, FirstName = "Jasmine", LastName = "Doe", Salary = 5500M},
            new Driver { DriverId = 9, FirstName = "Jared", LastName = "Doe", Salary = 6000M},
            new Driver { DriverId = 10, FirstName = "Jocelyn", LastName = "Doe", Salary = 6500M}
            );

        modelBuilder.Entity<Enterprise>().HasData(
            new Enterprise { EnterpriseId = 1, Name = "MotorPool", City = "New York", Street = "5th Avenue", VAT = "US123456789" },
            new Enterprise { EnterpriseId = 2, Name = "MotorPool", City = "Los Angeles", Street = "Hollywood Boulevard", VAT = "US987654321" },
            new Enterprise { EnterpriseId = 3, Name = "MotorPool", City = "Chicago", Street = "Michigan Avenue", VAT = "US123789456" },
            new Enterprise { EnterpriseId = 4, Name = "MotorPool", City = "Houston", Street = "Texas Avenue", VAT = "US456123789" },
            new Enterprise { EnterpriseId = 5, Name = "MotorPool", City = "Philadelphia", Street = "Benjamin Franklin Parkway", VAT = "US789456123" }
            );

        modelBuilder.Entity<EnterpriseDriver>().HasData(
            new EnterpriseDriver { EnterpriseDriverId = 1, EnterpriseId = 1, DriverId = 1, HiredOn = new DateTime(2020, 1, 1) },
            new EnterpriseDriver { EnterpriseDriverId = 2, EnterpriseId = 1, DriverId = 2, HiredOn = new DateTime(2020, 2, 1) },
            new EnterpriseDriver { EnterpriseDriverId = 3, EnterpriseId = 1, DriverId = 3, HiredOn = new DateTime(2020, 3, 1) },
            new EnterpriseDriver { EnterpriseDriverId = 4, EnterpriseId = 1, DriverId = 4, HiredOn = new DateTime(2020, 4, 1) },
            new EnterpriseDriver { EnterpriseDriverId = 5, EnterpriseId = 2, DriverId = 5, HiredOn = new DateTime(2020, 5, 1) },
            new EnterpriseDriver { EnterpriseDriverId = 6, EnterpriseId = 2, DriverId = 6, HiredOn = new DateTime(2020, 6, 1) },
            new EnterpriseDriver { EnterpriseDriverId = 7, EnterpriseId = 2, DriverId = 7, HiredOn = new DateTime(2020, 7, 1) },
            new EnterpriseDriver { EnterpriseDriverId = 8, EnterpriseId = 3, DriverId = 8, HiredOn = new DateTime(2020, 8, 1) }
            );

        modelBuilder.Entity<EnterpriseVehicle>().HasData(
            new EnterpriseVehicle { EnterpriseVehicleId = 1, EnterpriseId = 1, VehicleId = 1, AcquiredOn = new DateTime(2020, 1, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 2, EnterpriseId = 1, VehicleId = 2, AcquiredOn = new DateTime(2020, 2, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 3, EnterpriseId = 1, VehicleId = 3, AcquiredOn = new DateTime(2020, 3, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 4, EnterpriseId = 1, VehicleId = 4, AcquiredOn = new DateTime(2020, 4, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 5, EnterpriseId = 1, VehicleId = 5, AcquiredOn = new DateTime(2020, 5, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 6, EnterpriseId = 1, VehicleId = 6, AcquiredOn = new DateTime(2020, 6, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 7, EnterpriseId = 1, VehicleId = 7, AcquiredOn = new DateTime(2020, 7, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 8, EnterpriseId = 2, VehicleId = 8, AcquiredOn = new DateTime(2020, 8, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 9, EnterpriseId = 2, VehicleId = 9, AcquiredOn = new DateTime(2020, 9, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 10, EnterpriseId = 2, VehicleId = 10, AcquiredOn = new DateTime(2020, 10, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 11, EnterpriseId = 2, VehicleId = 11, AcquiredOn = new DateTime(2020, 11, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 12, EnterpriseId = 2, VehicleId = 12, AcquiredOn = new DateTime(2020, 12, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 13, EnterpriseId = 3, VehicleId = 13, AcquiredOn = new DateTime(2020, 1, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 14, EnterpriseId = 3, VehicleId = 14, AcquiredOn = new DateTime(2020, 2, 1) },
            new EnterpriseVehicle { EnterpriseVehicleId = 15, EnterpriseId = 3, VehicleId = 15, AcquiredOn = new DateTime(2020, 3, 1) }
            );

        modelBuilder.Entity<EnterpriseVehicleDriver>()
                    .HasData(
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 1, EnterpriseVehicleId = 1, EnterpriseDriverId = 1, AssignedOn = new DateTime(2020, 1, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 2, EnterpriseVehicleId = 1, EnterpriseDriverId = 2, AssignedOn = new DateTime(2020, 2, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 3, EnterpriseVehicleId = 1, EnterpriseDriverId = 3, AssignedOn = new DateTime(2020, 3, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 4, EnterpriseVehicleId = 1, EnterpriseDriverId = 4, AssignedOn = new DateTime(2020, 4, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 5, EnterpriseVehicleId = 2, EnterpriseDriverId = 1, AssignedOn = new DateTime(2020, 5, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 6, EnterpriseVehicleId = 2, EnterpriseDriverId = 2, AssignedOn = new DateTime(2020, 6, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 7, EnterpriseVehicleId = 2, EnterpriseDriverId = 3, AssignedOn = new DateTime(2020, 7, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 8, EnterpriseVehicleId = 2, EnterpriseDriverId = 4, AssignedOn = new DateTime(2020, 8, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 9, EnterpriseVehicleId = 3, EnterpriseDriverId = 1, AssignedOn = new DateTime(2020, 9, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 10, EnterpriseVehicleId = 3, EnterpriseDriverId = 2, AssignedOn = new DateTime(2020, 10, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 11, EnterpriseVehicleId = 3, EnterpriseDriverId = 3, AssignedOn = new DateTime(2020, 11, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 12, EnterpriseVehicleId = 4, EnterpriseDriverId = 1, AssignedOn = new DateTime(2020, 12, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 13, EnterpriseVehicleId = 5, EnterpriseDriverId = 2, AssignedOn = new DateTime(2020, 1, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 14, EnterpriseVehicleId = 6, EnterpriseDriverId = 3, AssignedOn = new DateTime(2020, 2, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 15, EnterpriseVehicleId = 8, EnterpriseDriverId = 5, AssignedOn = new DateTime(2020, 4, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 16, EnterpriseVehicleId = 8, EnterpriseDriverId = 6, AssignedOn = new DateTime(2020, 5, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 17, EnterpriseVehicleId = 8, EnterpriseDriverId = 7, AssignedOn = new DateTime(2020, 6, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 18, EnterpriseVehicleId = 9, EnterpriseDriverId = 5, AssignedOn = new DateTime(2020, 7, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 19, EnterpriseVehicleId = 9, EnterpriseDriverId = 6, AssignedOn = new DateTime(2020, 8, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 20, EnterpriseVehicleId = 9, EnterpriseDriverId = 7, AssignedOn = new DateTime(2020, 9, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 21, EnterpriseVehicleId = 10, EnterpriseDriverId = 5, AssignedOn = new DateTime(2020, 10, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 22, EnterpriseVehicleId = 10, EnterpriseDriverId = 6, AssignedOn = new DateTime(2020, 11, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 23, EnterpriseVehicleId = 10, EnterpriseDriverId = 7, AssignedOn = new DateTime(2020, 12, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 24, EnterpriseVehicleId = 11, EnterpriseDriverId = 5, AssignedOn = new DateTime(2020, 1, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 25, EnterpriseVehicleId = 13, EnterpriseDriverId = 8, AssignedOn = new DateTime(2020, 3, 1) },
                        new EnterpriseVehicleDriver { EnterpriseVehicleDriverId = 26, EnterpriseVehicleId = 14, EnterpriseDriverId = 8, AssignedOn = new DateTime(2020, 4, 1) }
                    );

        modelBuilder.Entity<ActiveDriver>().HasData(
            new ActiveDriver { ActiveDriverId = 1, EnterpriseVehicleDriverId = 1, StartedOn = new DateTime(2020, 1, 1) },
            new ActiveDriver { ActiveDriverId = 2, EnterpriseVehicleDriverId = 6, StartedOn = new DateTime(2020, 2, 1) },
            new ActiveDriver { ActiveDriverId = 3, EnterpriseVehicleDriverId = 11, StartedOn = new DateTime(2020, 3, 1) }
        );
    }

}