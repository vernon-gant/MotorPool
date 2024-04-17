namespace MotorPool.Domain.Reports;

public class VehicleMileageReport : AbstractReport
{
    public override string Type => "Vehicle mileage";

    public int VehicleId { get; set; }
}