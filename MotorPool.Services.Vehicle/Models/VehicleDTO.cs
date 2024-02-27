using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MotorPool.Abstractions;
using MotorPool.Utils.ValidationAttributes;

namespace MotorPool.Services.Vehicles.Models;

public class VehicleDTO : EnterpriseOwnedEntity
{

    public int VehicleId { get; set; }

    [MinLength(17)]
    [MaxLength(17)]
    [Display(Name = "VIN")]
    public string MotorVIN { get; set; }

    [Required]
    [Range(1, 1000000)]
    public decimal Cost { get; set; }

    [Display(Name = "Manufacture year")]
    [DateRange(MinYear = 2000)]
    public int ManufactureYear { get; set; }

    [Display(Name = "Manufacture land")]
    [Required]
    [ExistingCounty]
    public string ManufactureLand { get; set; }

    [Display(Name = "Mileage (km)")]
    [Range(0, 1000000)]
    public decimal Mileage { get; set; }

    public int VehicleBrandId { get; set; }

}