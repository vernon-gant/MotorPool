using MotorPool.Domain;

namespace MotorPool.Services.VehicleBrand.ViewModels;

public class VehicleBrandViewModel
{

    public int VehicleBrandId { get; set; }

    public string CompanyName { get; set; }

    public string ModelName { get; set; }

    public string Type { get; set; }

    public decimal FuelTankCapacityLiters { get; set; }

    public decimal PayloadCapacityKg { get; set; }

    public int NumberOfSeats { get; set; }

    public int ReleaseYear { get; set; }

}