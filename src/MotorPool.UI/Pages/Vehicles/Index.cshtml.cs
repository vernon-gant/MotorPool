using Microsoft.AspNetCore.Mvc;

using MotorPool.Services.Manager;
using MotorPool.Services.Utils;
using MotorPool.Services.Vehicles;
using MotorPool.Services.Vehicles.Models;
using MotorPool.Services.Vehicles.Services;
using MotorPool.UI.Pages.Shared;

namespace MotorPool.UI.Pages.Vehicles;

public class IndexModel(VehicleQueryService vehicleQueryService, ManagerPermissionService permissionService) : PagedModel
{

    public override int ELEMENTS_PER_PAGE => 10;

    public override int PAGES_DISPLAY_RANGE => 5;

    public IList<VehicleViewModel> Vehicles { get; set; } = default!;

    public string? EnterpriseName { get; set; }

    public string? VehicleBrandSignature { get; set; }

    public async Task<IActionResult> OnGetAsync(VehicleQueryOptions queryOptions, PageOptionsDTO pageOptions, string? enterpriseName)
    {
        CurrentPage = pageOptions.CurrentPage ?? PageOptions.DEFAULT_PAGE_NUMBER;

        queryOptions.ManagerId = queryOptions.EnterpriseId.HasValue ? null : User.GetManagerId();

        EnterpriseName = enterpriseName;

        if (queryOptions.EnterpriseId.HasValue && !await permissionService.IsManagerAccessibleEnterprise(User.GetManagerId(), queryOptions.EnterpriseId.Value)) return Forbid();

        PagedViewModel<VehicleViewModel> enterpriseVehicles = await vehicleQueryService.GetAllAsync(pageOptions.ToPageOptions(ELEMENTS_PER_PAGE), queryOptions);

        TotalPages = enterpriseVehicles.TotalPages;
        Vehicles = enterpriseVehicles.Elements;

        VehicleBrandSignature = queryOptions.VehicleBrandId.HasValue ? Vehicles.First().CompanyName + " " + Vehicles.First().ModelName : null;

        HttpContext.Session.SetString("VehicleIndexReturnUrl", Request.Path + Request.QueryString);

        return Page();
    }

}