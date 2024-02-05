using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;

namespace MotorPool.UI.Pages.Admin.Vehicles;

public class VehicleBrandsSelectListPageModel : PageModel
{

    public SelectList VehicleBrandSelectList { get; set; }

    public void PopulateVehicleBrandsDropDownList(AppDbContext context, object? selectedVehicleBrand = null)
    {
        var vehicleBrands = context.VehicleBrands
                                   .OrderBy(vehicleBrand => vehicleBrand.CompanyName)
                                   .Select(vehicleBrand => new
                                   {
                                       vehicleBrand.VehicleBrandId, BrandSignature = $"{vehicleBrand.CompanyName} - {vehicleBrand.ModelName}"
                                   })
                                   .AsNoTracking();

        VehicleBrandSelectList = new (vehicleBrands, nameof(VehicleBrand.VehicleBrandId), "BrandSignature", selectedVehicleBrand);
    }

}