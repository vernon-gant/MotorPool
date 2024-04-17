using Microsoft.AspNetCore.Mvc;

using MotorPool.Domain.Reports;
using MotorPool.Services.Reporting.Core;
using MotorPool.Services.Reporting.DTO;

namespace MotorPool.API.Endpoints;

public static class ReportEndpoints
{
    public static void MapReportEndpoints(this IEndpointRouteBuilder managerResourcesGroupBuilder)
    {
        RouteGroupBuilder enterprisesGroupBuilder = managerResourcesGroupBuilder.MapGroup("reports");

        enterprisesGroupBuilder.MapPost("vehicle-mileage", VehicleMileage);
    }

    private static async ValueTask<IResult> VehicleMileage(
        [FromBody] VehicleMileageReportDTO reportDto,
        [FromServices] ReportService<VehicleMileageReport,VehicleMileageReportDTO> reportService)
    {
        return Results.Ok(await reportService.Generate(reportDto));
    }
}