using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotorPool.Services.Enterprise.Models;

public class SimpleEnterpriseViewModel : EnterpriseDTO
{
    public int EnterpriseId { get; set; }

    [Display(Name = "Founded on")]
    public DateTime FoundedOn { get; set; }

    [JsonIgnore]
    public List<int> ManagerIds { get; set; } = new ();

}

public class FullEnterpriseViewModel : SimpleEnterpriseViewModel
{

    public List<int> VehicleIds { get; set; } = new ();

    public List<int> DriverIds { get; set; } = new ();

}