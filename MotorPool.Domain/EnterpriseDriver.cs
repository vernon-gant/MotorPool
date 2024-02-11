using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class EnterpriseDriver
{

    [Key]
    public int EnterpriseDriverId { get; set; }

    public int DriverId { get; set; }

    public Driver Driver { get; set; } = null!;

    public int EnterpriseId { get; set; }

    public Enterprise Enterprise { get; set; } = null!;

    public DateTime HiredOn { get; set; }

    public ICollection<EnterpriseVehicleDriver> EnterpriseVehicleLinks { get; set; }

}