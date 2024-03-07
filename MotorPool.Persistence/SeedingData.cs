using MotorPool.Domain;

namespace MotorPool.Persistence;

public static class SeedingData
{

    public static List<VehicleBrand> VehicleBrands =>
    [
        new VehicleBrand
        {
            VehicleBrandId = 1, CompanyName = "Toyota", ModelName = "Corolla", Type = VehicleType.PassengerCar, FuelTankCapacityLiters = 50, PayloadCapacityKg = 450,
            NumberOfSeats = 5, ReleaseYear = 2020
        },
        new VehicleBrand
        {
            VehicleBrandId = 2, CompanyName = "Volvo", ModelName = "B7R", Type = VehicleType.Bus, FuelTankCapacityLiters = 300, PayloadCapacityKg = 7500, NumberOfSeats = 50,
            ReleaseYear = 2019
        },
        new VehicleBrand
        {
            VehicleBrandId = 3, CompanyName = "Scania", ModelName = "P Series", Type = VehicleType.Truck, FuelTankCapacityLiters = 400, PayloadCapacityKg = 15000,
            NumberOfSeats = 3, ReleaseYear = 2018
        },
        new VehicleBrand
        {
            VehicleBrandId = 4, CompanyName = "Mercedes-Benz", ModelName = "Citaro", Type = VehicleType.Bus, FuelTankCapacityLiters = 275, PayloadCapacityKg = 18000,
            NumberOfSeats = 45, ReleaseYear = 2021
        },
        new VehicleBrand
        {
            VehicleBrandId = 5, CompanyName = "Ford", ModelName = "Transit", Type = VehicleType.Truck, FuelTankCapacityLiters = 80, PayloadCapacityKg = 1200, NumberOfSeats = 3,
            ReleaseYear = 2022
        }
    ];

    public static List<Enterprise> Enterprises =>
    [
        new Enterprise { EnterpriseId = 1, Name = "MotorPool", City = "New York", Street = "5th Avenue", VAT = "US123456789" },
        new Enterprise { EnterpriseId = 2, Name = "MotorPool", City = "Los Angeles", Street = "Hollywood Boulevard", VAT = "US987654321" },
        new Enterprise { EnterpriseId = 3, Name = "MotorPool", City = "Chicago", Street = "Michigan Avenue", VAT = "US123789456" },
        new Enterprise { EnterpriseId = 4, Name = "MotorPool", City = "Houston", Street = "Texas Avenue", VAT = "US456123789" },
        new Enterprise { EnterpriseId = 5, Name = "MotorPool", City = "Philadelphia", Street = "Benjamin Franklin Parkway", VAT = "US789456123" }
    ];

    public static List<Manager> Managers =>
    [
        new Manager { ManagerId = 1 },
        new Manager { ManagerId = 2 },
        new Manager { ManagerId = 3 }
    ];

    public static List<EnterpriseManager> EnterpriseManagers =>
    [
        new EnterpriseManager { EnterpriseId = 1, ManagerId = 1 },
        new EnterpriseManager { EnterpriseId = 1, ManagerId = 2 },
        new EnterpriseManager { EnterpriseId = 2, ManagerId = 1 },
        new EnterpriseManager { EnterpriseId = 2, ManagerId = 2 },
        new EnterpriseManager { EnterpriseId = 3, ManagerId = 1 },
        new EnterpriseManager { EnterpriseId = 3, ManagerId = 3 },
        new EnterpriseManager { EnterpriseId = 4, ManagerId = 1 },
        new EnterpriseManager { EnterpriseId = 5, ManagerId = 1 }
    ];

}