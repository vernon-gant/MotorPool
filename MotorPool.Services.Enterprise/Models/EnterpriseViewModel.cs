namespace MotorPool.Services.Enterprise.Models;

public class EnterpriseViewModel
{

    public int EnterpriseId { get; set; }

    public required string Name { get; set; }

    public required string City { get; set; }

    public required string Street { get; set; }

    public required string VAT { get; set; }

    public DateTime FoundedOn { get; set; }

    public List<VehicleSummaryViewModel> Vehicles { get; set; } = new ();

    public List<DriverSummaryViewModel> Drivers { get; set; } = new ();

}

public class VehicleSummaryViewModel
{

    public int VehicleId { get; set; }

    public required string CompanyName { get; set; }

    public required string ModelName { get; set; }

    public required string VIN { get; set; }

}

public class DriverSummaryViewModel
{

    public int DriverId { get; set; }

    public required string FullName { get; set; }

    public decimal Salary { get; set; }

}