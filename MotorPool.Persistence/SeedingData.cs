using MotorPool.Domain;

namespace MotorPool.Persistence;

public static class SeedingData
{

    public static List<VehicleBrand> VehicleBrands =>
    [
        new ()
        {
            VehicleBrandId = 1, CompanyName = "Toyota", ModelName = "Corolla", Type = VehicleType.PassengerCar, FuelTankCapacityLiters = 50, PayloadCapacityKg = 450,
            NumberOfSeats = 5, ReleaseYear = 2020
        },
        new ()
        {
            VehicleBrandId = 2, CompanyName = "Volvo", ModelName = "B7R", Type = VehicleType.Bus, FuelTankCapacityLiters = 300, PayloadCapacityKg = 7500, NumberOfSeats = 50,
            ReleaseYear = 2019
        },
        new ()
        {
            VehicleBrandId = 3, CompanyName = "Scania", ModelName = "P Series", Type = VehicleType.Truck, FuelTankCapacityLiters = 400, PayloadCapacityKg = 15000,
            NumberOfSeats = 3, ReleaseYear = 2018
        },
        new ()
        {
            VehicleBrandId = 4, CompanyName = "Mercedes-Benz", ModelName = "Citaro", Type = VehicleType.Bus, FuelTankCapacityLiters = 275, PayloadCapacityKg = 18000,
            NumberOfSeats = 45, ReleaseYear = 2021
        },
        new ()
        {
            VehicleBrandId = 5, CompanyName = "Ford", ModelName = "Transit", Type = VehicleType.Truck, FuelTankCapacityLiters = 80, PayloadCapacityKg = 1200, NumberOfSeats = 3,
            ReleaseYear = 2022
        }
    ];

    public static List<Enterprise> Enterprises =>
    [
        new () { EnterpriseId = 1, Name = "MotorPool", City = "New York", Street = "5th Avenue", VAT = "US123456789" },
        new () { EnterpriseId = 2, Name = "MotorPool", City = "Los Angeles", Street = "Hollywood Boulevard", VAT = "US987654321" },
        new () { EnterpriseId = 3, Name = "MotorPool", City = "Chicago", Street = "Michigan Avenue", VAT = "US123789456" },
        new () { EnterpriseId = 4, Name = "MotorPool", City = "Houston", Street = "Texas Avenue", VAT = "US456123789" },
        new () { EnterpriseId = 5, Name = "MotorPool", City = "Philadelphia", Street = "Benjamin Franklin Parkway", VAT = "US789456123" }
    ];
    public static List<Vehicle> Vehicles =>
    [
        new ()
        {
            VehicleId = 1, MotorVIN = "1HGBH41JXMN109186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 20000M, Mileage = 15000M, VehicleBrandId = 1, EnterpriseId = 1
        },
        new ()
        {
            VehicleId = 2, MotorVIN = "2VOLVOB7R0MN10918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 100000M, Mileage = 50000M, VehicleBrandId = 2,
            EnterpriseId = 1
        },
        new ()
        {
            VehicleId = 3, MotorVIN = "3SCANPSE0MN109187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 120000M, Mileage = 20000M, VehicleBrandId = 3,
            EnterpriseId = 1
        },
        new ()
        {
            VehicleId = 4, MotorVIN = "4MBNZCTR0MN109186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 110000M, Mileage = 30000M, VehicleBrandId = 4,
            EnterpriseId = 1
        },
        new ()
        {
            VehicleId = 5, MotorVIN = "5FORDTRN0MN109185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 30000M, Mileage = 10000M, VehicleBrandId = 5, EnterpriseId = 1
        },
        new ()
        {
            VehicleId = 6, MotorVIN = "6HGBH41JXMN209186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 22000M, Mileage = 12000M, VehicleBrandId = 1, EnterpriseId = 2
        },
        new ()
        {
            VehicleId = 7, MotorVIN = "7VOLVOB7R1MN20918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 105000M, Mileage = 55000M, VehicleBrandId = 2,
            EnterpriseId = 2
        },
        new ()
        {
            VehicleId = 8, MotorVIN = "8SCANPSE1MN209187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 125000M, Mileage = 22000M, VehicleBrandId = 3,
            EnterpriseId = 2
        },
        new ()
        {
            VehicleId = 9, MotorVIN = "9MBNZCTR1MN209186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 115000M, Mileage = 32000M, VehicleBrandId = 4,
            EnterpriseId = 2
        },
        new ()
        {
            VehicleId = 10, MotorVIN = "0FORDTRN1MN209185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 32000M, Mileage = 11000M, VehicleBrandId = 5, EnterpriseId = 3
        },
        new ()
        {
            VehicleId = 11, MotorVIN = "1HGBH41JXMN309186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 23000M, Mileage = 13000M, VehicleBrandId = 1, EnterpriseId = 3
        },
        new ()
        {
            VehicleId = 12, MotorVIN = "2VOLVOB7R2MN30918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 110000M, Mileage = 60000M, VehicleBrandId = 2,
            EnterpriseId = 3
        },
        new () { VehicleId = 13, MotorVIN = "3SCANPSE2MN309187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 130000M, Mileage = 24000M, VehicleBrandId = 3 },
        new () { VehicleId = 14, MotorVIN = "4MBNZCTR2MN309186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 120000M, Mileage = 33000M, VehicleBrandId = 4 },
        new () { VehicleId = 15, MotorVIN = "5FORDTRN2MN309185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 34000M, Mileage = 12000M, VehicleBrandId = 5 },
        new () { VehicleId = 16, MotorVIN = "6HGBH41JXMN409186", ManufactureYear = 2020, ManufactureLand = "Japan", Cost = 24000M, Mileage = 14000M, VehicleBrandId = 1 },
        new () { VehicleId = 17, MotorVIN = "7VOLVOB7R3MN40918", ManufactureYear = 2019, ManufactureLand = "Sweden", Cost = 115000M, Mileage = 65000M, VehicleBrandId = 2 },
        new () { VehicleId = 18, MotorVIN = "8SCANPSE3MN409187", ManufactureYear = 2018, ManufactureLand = "Sweden", Cost = 135000M, Mileage = 26000M, VehicleBrandId = 3 },
        new () { VehicleId = 19, MotorVIN = "9MBNZCTR3MN409186", ManufactureYear = 2021, ManufactureLand = "Germany", Cost = 125000M, Mileage = 34000M, VehicleBrandId = 4 },
        new () { VehicleId = 20, MotorVIN = "0FORDTRN3MN409185", ManufactureYear = 2022, ManufactureLand = "USA", Cost = 36000M, Mileage = 13000M, VehicleBrandId = 5 }
    ];

    public static List<Driver> Drivers =>
    [
        new Driver { DriverId = 1, FirstName = "John", LastName = "Doe", Salary = 2000M, EnterpriseId = 1 },
        new Driver { DriverId = 2, FirstName = "Jane", LastName = "Doe", Salary = 2500M, EnterpriseId = 1 },
        new Driver { DriverId = 3, FirstName = "Jack", LastName = "Doe", Salary = 3000M, EnterpriseId = 1 },
        new Driver { DriverId = 4, FirstName = "Jill", LastName = "Doe", Salary = 3500M, EnterpriseId = 1 },
        new Driver { DriverId = 5, FirstName = "Jim", LastName = "Doe", Salary = 4000M, EnterpriseId = 2 },
        new Driver { DriverId = 6, FirstName = "Jenny", LastName = "Doe", Salary = 4500M, EnterpriseId = 2 },
        new Driver { DriverId = 7, FirstName = "Jasper", LastName = "Doe", Salary = 5000M, EnterpriseId = 2 },
        new Driver { DriverId = 8, FirstName = "Jasmine", LastName = "Doe", Salary = 5500M, EnterpriseId = 3 },
        new Driver { DriverId = 9, FirstName = "Jared", LastName = "Doe", Salary = 6000M, EnterpriseId = 3 },
        new Driver { DriverId = 10, FirstName = "Jocelyn", LastName = "Doe", Salary = 6500M }
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

    public static List<DriverVehicle> GenerateDriverVehicleAssignments()
    {
        List<DriverVehicle> driverVehicles = new ();
        Random random = new ();

        foreach (IGrouping<int?, Vehicle> enterpriseGroup in Vehicles.GroupBy(v => v.EnterpriseId))
        {
            if (enterpriseGroup.Key is null) continue;

            List<Driver> enterpriseDrivers = Drivers.Where(d => d.EnterpriseId == enterpriseGroup.Key).ToList();

            foreach (Vehicle vehicle in enterpriseGroup)
            {
                List<Driver> assignedDrivers = enterpriseDrivers.OrderBy(x => random.Next()).Take(3).ToList();

                foreach (Driver driver in assignedDrivers) driverVehicles.Add(new DriverVehicle { DriverId = driver.DriverId, VehicleId = vehicle.VehicleId });
            }
        }

        return driverVehicles;
    }

}