using System.Text.Json.Serialization;

namespace MotorPool.Services.Enterprise.Models;

public class EnterpriseViewModel : EnterpriseDTO
{

    public int EnterpriseId { get; set; }

    public DateTime FoundedOn { get; set; }

    public List<int> VehicleIds { get; set; } = new ();

    public List<int> DriverIds { get; set; } = new ();

    [JsonIgnore]
    public List<int> ManagerIds { get; set; } = new ();

}