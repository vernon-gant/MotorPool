using System.ComponentModel.DataAnnotations;

using MotorPool.Abstractions;
using MotorPool.Utils.ValidationAttributes;

namespace MotorPool.Services.Vehicles.Models;

public class VehicleDTO : EnterpriseOwned
{

    [MinLength(17)]
    [MaxLength(17)]
    [Display(Name = "VIN")]
    [Required]
    public string MotorVIN { get; set; }

    [Required]
    [Range(1, 1000000)]
    public decimal Cost { get; set; }

    [Display(Name = "Manufacture year")]
    [DateRange(MinYear = 2000)]
    [Required]
    public int ManufactureYear { get; set; }

    [Display(Name = "Manufacture land")]
    [Required]
    [ExistingCounty]
    public string ManufactureLand { get; set; }

    [Display(Name = "Mileage (km)")]
    [Range(0, 1000000)]
    public decimal Mileage { get; set; }

    [Display(Name = "Vehicle brand")]
    [Required]
    public int VehicleBrandId { get; set; }

    public int? EnterpriseId { get; set; }

}