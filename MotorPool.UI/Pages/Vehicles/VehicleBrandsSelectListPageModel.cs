using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.VehicleBrand.Services;
using MotorPool.Services.VehicleBrand.ViewModels;

namespace MotorPool.UI.Pages.Admin.Vehicles;

public class VehicleBrandsSelectListPageModel : PageModel
{

    public SelectList VehicleBrandSelectList { get; set; }

    public async void PopulateVehicleBrandsDropDownList(VehicleBrandService vehicleBrandService, object? selectedVehicleBrand = null)
    {
        List<VehicleBrandSignatureWithId> vehicleBrandSignatureWithIds = await vehicleBrandService.GetVehicleBrandsWithIdAsync();

        VehicleBrandSelectList = new (vehicleBrandSignatureWithIds, nameof(VehicleBrandSignatureWithId.VehicleBrandId), nameof(VehicleBrandSignatureWithId.BrandSignature), selectedVehicleBrand);
    }

}