namespace MotorPool.Domain;

public class ActiveDriver
{

    public int ActiveDriverId { get; set; }

    public int EnterpriseVehicleDriverId { get; set; }

    public EnterpriseVehicleDriver EnterpriseVehicleDriver { get; set; } = null!;

    public DateTime StartedOn { get; set; }

    public DateTime? StoppedOn { get; set; }

}