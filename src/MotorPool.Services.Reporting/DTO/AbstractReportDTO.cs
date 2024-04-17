using System.ComponentModel.DataAnnotations;

using MotorPool.Domain.Reports;

namespace MotorPool.Services.Reporting.DTO;

public abstract class AbstractReportDTO
{
    [Required]
    public required DateOnly StartTime { get; init; }

    [Required]
    public required DateOnly EndTime { get; init; }

    [Required]
    public required Period Period { get; init; }
}