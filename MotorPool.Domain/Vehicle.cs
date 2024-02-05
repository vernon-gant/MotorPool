using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class Vehicle
{

    public int VehicleId { get; set; }

    [MinLength(17)]
    [MaxLength(17)]
    [Required]
    public string MotorVIN { get; set; }

    [DisplayFormat(DataFormatString = "{0:C}")]
    public decimal Cost { get; set; }

    [Required]
    public int ManufactureYear { get; set; }

    [MaxLength(100)]
    public string ManufactureLand { get; set; }

    [Required]
    public decimal Mileage { get; set; }

    public int VehicleBrandId { get; set; }

    public VehicleBrand VehicleBrand { get; set; }

}