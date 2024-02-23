namespace MotorPool.Services.VehicleBrand.Models;

public class VehicleBrandDTO
{

    public required string CompanyName { get; set; }

    public required string ModelName { get; set; }

    public required string Type { get; set; }

    public decimal FuelTankCapacityLiters { get; set; }

    public decimal PayloadCapacityKg { get; set; }

    public int NumberOfSeats { get; set; }

    public int ReleaseYear { get; set; }

}