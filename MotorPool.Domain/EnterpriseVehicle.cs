using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class EnterpriseVehicle
{

    [Key]
    public int EnterpriseVehicleId { get; set; }

    public int VehicleId { get; set; }

    public Vehicle Vehicle { get; set; } = null!;

    public int EnterpriseId { get; set; }

    public Enterprise Enterprise { get; set; } = null!;

    public DateTime AcquiredOn { get; set; }

    public ICollection<EnterpriseVehicleDriver> EnterpriseDriverLinks { get; set; }

}