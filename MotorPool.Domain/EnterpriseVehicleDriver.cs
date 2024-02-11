using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class EnterpriseVehicleDriver
{

    [Key]
    public int EnterpriseVehicleDriverId { get; set; }

    public int EnterpriseVehicleId { get; set; }

    public EnterpriseVehicle EnterpriseVehicle { get; set; } = null!;

    public int EnterpriseDriverId { get; set; }

    public EnterpriseDriver EnterpriseDriver { get; set; } = null!;

    public DateTime AssignedOn { get; set; }

    public ActiveDriver? ActiveDriver { get; set; }

}