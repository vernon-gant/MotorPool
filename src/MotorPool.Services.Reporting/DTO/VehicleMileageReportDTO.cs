using System.ComponentModel.DataAnnotations;

namespace MotorPool.Services.Reporting.DTO;

public class VehicleMileageReportDTO : AbstractReportDTO
{

    [Required]
    public int VehicleId { get; set; }
}