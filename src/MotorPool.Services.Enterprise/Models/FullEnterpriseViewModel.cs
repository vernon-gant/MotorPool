namespace MotorPool.Services.Enterprise.Models;

public class FullEnterpriseViewModel : SimpleEnterpriseViewModel
{

    public List<int> VehicleIds { get; set; } = new ();

    public List<int> DriverIds { get; set; } = new ();

}