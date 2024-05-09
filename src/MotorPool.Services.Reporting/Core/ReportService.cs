using AutoMapper;

using MotorPool.Domain.Reports;
using MotorPool.Services.Reporting.DTO;

namespace MotorPool.Services.Reporting.Core;

public class ReportService<TReport, TDto>(IMapper mapper, IEnumerable<ReportPeriodResolver<TReport>> reportResolvers) where TReport : AbstractReport where TDto : ReportDTO
{
    private Func<TReport, ValueTask> Get(Period period) => reportResolvers.FirstOrDefault(reportPeriodResolver => reportPeriodResolver.CanResolve(period))?.Resolve(period) ??
                                                           throw new NotSupportedException("Not supported period...");

    public async ValueTask<TReport> Generate(TDto dto)
    {
        Func<TReport, ValueTask> reportGenerationFunc = Get(dto.Period);
        TReport report = mapper.Map<TReport>(dto);
        await reportGenerationFunc(report);

        return report;
    }
}