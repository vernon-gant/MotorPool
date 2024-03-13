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
        new Enterprise
        {
            EnterpriseId = 1, Name = "Garosh industries", City = "New York", Street = "5th Avenue", VAT = "US123456789", TimeZoneId = "America/New_York",
            FoundedOn = DateOnly.FromDateTime(new DateTime(2012, 1, 1))
        },
        new Enterprise
        {
            EnterpriseId = 2, Name = "Apple", City = "Los Angeles", Street = "Hollywood Boulevard", VAT = "US987654321", TimeZoneId = "America/Los_Angeles",
            FoundedOn = DateOnly.FromDateTime(new DateTime(2004, 4, 1))
        },
        new Enterprise
        {
            EnterpriseId = 3, Name = "Microsoft", City = "Chicago", Street = "Michigan Avenue", VAT = "US123789456", TimeZoneId = "America/Chicago",
            FoundedOn = DateOnly.FromDateTime(new DateTime(2000, 4, 4))
        },
        new Enterprise
        {
            EnterpriseId = 4, Name = "Amazon", City = "Houston", Street = "Texas Avenue", VAT = "US456123789", TimeZoneId = "America/Chicago",
            FoundedOn = DateOnly.FromDateTime(new DateTime(1994, 7, 5))
        },
        new Enterprise
        {
            EnterpriseId = 5, Name = "Tochmash", City = "Vladimir", Street = "Severnaya Street", VAT = "RU789456123", TimeZoneId = "Europe/Moscow",
            FoundedOn = DateOnly.FromDateTime(new DateTime(1950, 1, 1))
        },
        new Enterprise
        {
            EnterpriseId = 6, Name = "SAP", City = "Berlin", Street = "Wehlistrasse", VAT = "DE3242354325", TimeZoneId = "Etc/UTC",
            FoundedOn = DateOnly.FromDateTime(new DateTime(1990, 4, 1))
        }
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
        new EnterpriseManager { EnterpriseId = 5, ManagerId = 1 },
        new EnterpriseManager { EnterpriseId = 6, ManagerId = 3 }
    ];

    private static DateTime FirstTrackDateTime = DateTime.UtcNow.AddMonths(-1).AddDays(-5);

    private static DateTime SecondTrackDateTime = DateTime.UtcNow.AddMonths(-3).AddDays(-4).AddHours(-3);

    private static DateTime ThirdTrackDateTime = DateTime.UtcNow.AddMonths(-2).AddDays(2).AddHours(4);

    public static List<GeoPoint> GeoPoints =>
    [
        new GeoPoint { GeoPointId = 1, Latitude = 40.730610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime },
        new GeoPoint { GeoPointId = 2, Latitude = 40.731610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(1) },
        new GeoPoint { GeoPointId = 3, Latitude = 40.732610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(2).AddMinutes(30) },
        new GeoPoint { GeoPointId = 4, Latitude = 40.733610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(3).AddMinutes(15) },
        new GeoPoint { GeoPointId = 5, Latitude = 40.734610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(4).AddMinutes(45) },
        new GeoPoint { GeoPointId = 6, Latitude = 40.735610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(5).AddMinutes(30) },
        new GeoPoint { GeoPointId = 7, Latitude = 40.736610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(6).AddMinutes(15) },
        new GeoPoint { GeoPointId = 8, Latitude = 40.737610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(7).AddMinutes(45) },
        new GeoPoint { GeoPointId = 9, Latitude = 40.738610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(8).AddMinutes(30) },
        new GeoPoint { GeoPointId = 10, Latitude = 40.739610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(9).AddMinutes(15) },
        new GeoPoint { GeoPointId = 11, Latitude = 40.740610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(10).AddMinutes(45) },
        new GeoPoint { GeoPointId = 12, Latitude = 40.741610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(11).AddMinutes(30) },
        new GeoPoint { GeoPointId = 13, Latitude = 40.742610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(12).AddMinutes(15) },
        new GeoPoint { GeoPointId = 14, Latitude = 40.743610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(13).AddMinutes(45) },
        new GeoPoint { GeoPointId = 15, Latitude = 40.744610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(14).AddMinutes(30) },
        new GeoPoint { GeoPointId = 16, Latitude = 40.745610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(15).AddMinutes(15) },
        new GeoPoint { GeoPointId = 17, Latitude = 40.746610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(16).AddMinutes(45) },
        new GeoPoint { GeoPointId = 18, Latitude = 40.747610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(17).AddMinutes(30) },
        new GeoPoint { GeoPointId = 19, Latitude = 40.748610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(18).AddMinutes(15) },
        new GeoPoint { GeoPointId = 20, Latitude = 40.749610, Longitude = -73.935242, VehicleId = 15022, RecordedAt = FirstTrackDateTime.AddHours(19).AddMinutes(45) },

        new GeoPoint { GeoPointId = 21, Latitude = 48.2082, Longitude = 16.3738, VehicleId = 20213, RecordedAt = SecondTrackDateTime },
        new GeoPoint { GeoPointId = 22, Latitude = 48.2092, Longitude = 16.3748, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(1) },
        new GeoPoint { GeoPointId = 23, Latitude = 48.2102, Longitude = 16.3758, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(2).AddMinutes(30) },
        new GeoPoint { GeoPointId = 24, Latitude = 48.2112, Longitude = 16.3768, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(3).AddMinutes(15) },
        new GeoPoint { GeoPointId = 25, Latitude = 48.2122, Longitude = 16.3778, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(4).AddMinutes(45) },
        new GeoPoint { GeoPointId = 26, Latitude = 48.2132, Longitude = 16.3788, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(5).AddMinutes(30) },
        new GeoPoint { GeoPointId = 27, Latitude = 48.2142, Longitude = 16.3798, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(6).AddMinutes(15) },
        new GeoPoint { GeoPointId = 28, Latitude = 48.2152, Longitude = 16.3808, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(7).AddMinutes(45) },
        new GeoPoint { GeoPointId = 29, Latitude = 48.2162, Longitude = 16.3818, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(8).AddMinutes(30) },
        new GeoPoint { GeoPointId = 30, Latitude = 48.2172, Longitude = 16.3828, VehicleId = 20213, RecordedAt = SecondTrackDateTime.AddHours(9).AddMinutes(15) },

        new GeoPoint { GeoPointId = 31, Latitude = 55.7558, Longitude = 37.6176, VehicleId = 27094, RecordedAt = ThirdTrackDateTime },
        new GeoPoint { GeoPointId = 32, Latitude = 55.7568, Longitude = 37.6186, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(1) },
        new GeoPoint { GeoPointId = 33, Latitude = 55.7578, Longitude = 37.6196, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(2).AddMinutes(30) },
        new GeoPoint { GeoPointId = 34, Latitude = 55.7588, Longitude = 37.6206, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(3).AddMinutes(15) },
        new GeoPoint { GeoPointId = 35, Latitude = 55.7598, Longitude = 37.6216, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(4).AddMinutes(45) },
        new GeoPoint { GeoPointId = 36, Latitude = 55.7608, Longitude = 37.6226, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(5).AddMinutes(30) },
        new GeoPoint { GeoPointId = 37, Latitude = 55.7618, Longitude = 37.6236, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(6).AddMinutes(15) },
        new GeoPoint { GeoPointId = 38, Latitude = 55.7628, Longitude = 37.6246, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(7).AddMinutes(45) },
        new GeoPoint { GeoPointId = 39, Latitude = 55.7638, Longitude = 37.6256, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(8).AddMinutes(30) },
        new GeoPoint { GeoPointId = 40, Latitude = 55.7648, Longitude = 37.6266, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(9).AddMinutes(15) },
        new GeoPoint { GeoPointId = 41, Latitude = 55.7658, Longitude = 37.6276, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(10).AddMinutes(45) },
        new GeoPoint { GeoPointId = 42, Latitude = 55.7668, Longitude = 37.6286, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(11).AddMinutes(30) },
        new GeoPoint { GeoPointId = 43, Latitude = 55.7678, Longitude = 37.6296, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(12).AddMinutes(15) },
        new GeoPoint { GeoPointId = 44, Latitude = 55.7688, Longitude = 37.6306, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(13).AddMinutes(45) },
        new GeoPoint { GeoPointId = 45, Latitude = 55.7698, Longitude = 37.6316, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(14).AddMinutes(30) },
        new GeoPoint { GeoPointId = 46, Latitude = 55.7708, Longitude = 37.6326, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(15).AddMinutes(15) },
        new GeoPoint { GeoPointId = 47, Latitude = 55.7718, Longitude = 37.6336, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(16).AddMinutes(45) },
        new GeoPoint { GeoPointId = 48, Latitude = 55.7728, Longitude = 37.6346, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(17).AddMinutes(30) },
        new GeoPoint { GeoPointId = 49, Latitude = 55.7738, Longitude = 37.6356, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(18).AddMinutes(15) },
        new GeoPoint { GeoPointId = 50, Latitude = 55.7748, Longitude = 37.6366, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(19).AddMinutes(45) },
        new GeoPoint { GeoPointId = 51, Latitude = 55.7758, Longitude = 37.6376, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(20).AddMinutes(30) },
        new GeoPoint { GeoPointId = 52, Latitude = 55.7768, Longitude = 37.6386, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(21).AddMinutes(15) },
        new GeoPoint { GeoPointId = 53, Latitude = 55.7778, Longitude = 37.6396, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(22).AddMinutes(45) },
        new GeoPoint { GeoPointId = 54, Latitude = 55.7788, Longitude = 37.6406, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(23).AddMinutes(30) },
        new GeoPoint { GeoPointId = 55, Latitude = 55.7798, Longitude = 37.6416, VehicleId = 27094, RecordedAt = ThirdTrackDateTime.AddHours(24).AddMinutes(15) }



    ];



}