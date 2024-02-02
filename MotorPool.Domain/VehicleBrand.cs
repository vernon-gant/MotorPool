using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class VehicleBrand
{

    public int VehicleBrandId { get; set; }

    [Required]
    [MaxLength(100)]
    public string CompanyName { get; set; }

    [Required]
    [MaxLength(100)]
    public string ModelName { get; set; }

    [Required]
    public VehicleType Type { get; set; }

    [Required]
    public decimal FuelTankCapacityLiters { get; set; }

    [Required]
    public decimal PayloadCapacityKg { get; set; }

    [Required]
    public int NumberOfSeats { get; set; }


    public int ReleaseYear { get; set; }

    public ICollection<Vehicle> Vehicles { get; set; }

}

public enum VehicleType
{
    [Display(Name = "Passenger car")]
    PassengerCar,
    [Display(Name = "Truck")]
    Truck,
    [Display(Name = "Bus")]
    Bus
}