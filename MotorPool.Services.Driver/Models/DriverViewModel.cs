using System.Text.Json.Serialization;

using MotorPool.Abstractions;

namespace MotorPool.Services.Drivers.Models;

public class DriverViewModel : DriverDTO, ManagersOwned
{

    public int DriverId { get; set; }

    public int? EnterpriseId { get; set; }

    public int? ActiveVehicleId { get; set; }

    public List<int> VehicleIds { get; set; } = new ();

    [JsonIgnore]
    public List<int> ManagerIds { get; set; } = new ();

}