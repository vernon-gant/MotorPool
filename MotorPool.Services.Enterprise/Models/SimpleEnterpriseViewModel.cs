using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotorPool.Services.Enterprise.Models;

public class SimpleEnterpriseViewModel : EnterpriseDTO
{
    public int EnterpriseId { get; set; }

    [Display(Name = "Founded on")]
    public DateOnly FoundedOn { get; set; }

    [Display(Name = "Time Zone")]
    public string TimeZoneId { get; set; } = string.Empty;

    [JsonIgnore]
    public List<int> ManagerIds { get; set; } = new ();

}