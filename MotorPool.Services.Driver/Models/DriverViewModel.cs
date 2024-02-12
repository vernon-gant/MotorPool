namespace MotorPool.Services.Drivers.Models;

public class DriverViewModel
{

    public int DriverId { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public decimal Salary { get; set; }

    public int? EnterpriseId { get; set; }

    public int? ActiveVehicleId { get; set; }

    public List<int> VehicleIds { get; set; } = new ();

}