namespace MotorPool.Services.Enterprise.Models;

public class EnterpriseViewModel
{

    public int EnterpriseId { get; set; }

    public required string Name { get; set; }

    public required string City { get; set; }

    public required string Street { get; set; }

    public required string VAT { get; set; }

    public DateTime FoundedOn { get; set; }

    public List<VehicleSummaryModel> Vehicles { get; set; } = new();

    public List<DriverSummaryModel> Drivers { get; set; } = new();

}

public class VehicleSummaryModel
{

    public int VehicleId { get; set; }

    public decimal Cost { get; set; }

    public string ModelName { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public int AssignedDriversCount { get; set; }

    public int? ActiveDriverId { get; set; }

}

public class DriverSummaryModel
{

    public int DriverId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime HiredOn { get; set; }

    public int AssignedVehiclesCount { get; set; }

    public int? ActiveVehicleId { get; set; }

}