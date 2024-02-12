using MotorPool.Services.Vehicles.ViewModels;

namespace MotorPool.Services.Vehicles.Models;

public class VehicleViewModel : VehicleDTO
{

    public required string CompanyName { get; set; }

    public required string ModelName { get; set; }

    public List<int> DriverIds { get; set; } = new ();

}