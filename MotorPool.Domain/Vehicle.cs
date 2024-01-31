using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class Vehicle
{

    public int VehicleId { get; set; }

    [MinLength(17)]
    [MaxLength(17)]
    [Required]
    public string VIN { get; set; }

    [MaxLength(100)]
    [Required]
    public string Manufacturer { get; set; }

    [MaxLength(100)]
    [Required]
    public string Model { get; set; }

    [Required]
    public int ManufactureYear { get; set; }

    [MaxLength(100)]
    public string ManufactureLand { get; set; }

    public decimal Cost { get; set; }

    [Required]
    public decimal Mileage { get; set; }

}