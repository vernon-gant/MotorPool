using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.VehicleBrand.ViewModels;

namespace MotorPool.UI.Pages.Vehicles;

public class VehicleBrandsSelectListPageModel : PageModel
{

    public SelectList VehicleBrandSelectList { get; set; }

    public async Task PopulateVehicleBrandsDropDownList(VehicleBrandService vehicleBrandService, object? selectedVehicleBrand = null)
    {
        var vehicleBrandSignatureWithIds = await vehicleBrandService.GetVehicleBrandsWithIdAsync();

        VehicleBrandSelectList = new SelectList(vehicleBrandSignatureWithIds, nameof(VehicleBrandSignatureWithId.VehicleBrandId),
                                                nameof(VehicleBrandSignatureWithId.BrandSignature), selectedVehicleBrand);
    }

}