namespace MotorPool.Services.Drivers.Models;

public class DriverViewModel
{

    public int DriverId { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public decimal Salary { get; set; }

    public int? EnterpriseId { get; set; }

    public int? ActiveVehicleId { get; set; }

    public List<VehicleSummary> Vehicles { get; set; } = new ();

}

public class VehicleSummary
{

    public int VehicleId { get; set; }

    public required string CompanyName { get; set; }

    public required string ModelName { get; set; }

}