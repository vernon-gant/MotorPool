using System.ComponentModel.DataAnnotations;

namespace MotorPool.Services.Vehicles.Models;

public class VehicleDTO
{
    public int VehicleId { get; set; }

    [MinLength(17)]
    [MaxLength(17)]
    public string MotorVIN { get; set; }

    public decimal Cost { get; set; }

    public int ManufactureYear { get; set; }

    public string ManufactureLand { get; set; }

    public decimal Mileage { get; set; }

    public int VehicleBrandId { get; set; }

}