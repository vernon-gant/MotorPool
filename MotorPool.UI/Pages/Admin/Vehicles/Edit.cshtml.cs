using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using MotorPool.Domain;
using MotorPool.Persistence;
using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.UI.Pages.Admin.Vehicles;

public class EditModel : PageModel
{

    private readonly AppDbContext _context;

    private readonly IMapper _mapper;

    public EditModel(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [BindProperty]
    public VehicleEditViewModel VehicleViewModel { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Vehicle? foundVehicle = await _context.Vehicles
                                              .Include(vehicle => vehicle.VehicleBrand)
                                              .FirstOrDefaultAsync(m => m.VehicleId == id);

        if (foundVehicle == null) return NotFound();

        VehicleViewModel = _mapper.Map<VehicleEditViewModel>(foundVehicle);
        ViewData["VehicleBrandId"] = new SelectList(_context.VehicleBrands, "VehicleBrandId", "CompanyName");

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        Vehicle oldVehicle = await _context.Vehicles
                                              .Include(vehicle => vehicle.VehicleBrand)
                                              .FirstAsync(vehicle => vehicle.VehicleId == VehicleViewModel.VehicleId);

        _mapper.Map(VehicleViewModel, oldVehicle);

        _context.Update(oldVehicle);

        await _context.SaveChangesAsync();

        return RedirectToPage("./List");
    }

    private bool VehicleExists(int id) => _context.Vehicles.Any(e => e.VehicleId == id);

}