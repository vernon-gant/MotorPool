namespace MotorPool.Services.Enterprise.Models;

public class EnterpriseViewModel
{

    public int EnterpriseId { get; set; }

    public required string Name { get; set; }

    public required string City { get; set; }

    public required string Street { get; set; }

    public required string VAT { get; set; }

    public DateTime FoundedOn { get; set; }

    public List<int> VehicleIds { get; set; } = new ();

    public List<int> DriverIds { get; set; } = new ();
}