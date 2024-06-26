﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MotorPool.Services.Vehicles.Models;

public class VehicleViewModel : VehicleDTO
{
    public int VehicleId { get; set; }

    [Display(Name = "Company name")]
    public required string CompanyName { get; set; }

    [Display(Name = "Model name")]
    public required string ModelName { get; set; }

    [Display(Name = "Acquired on")] public new string AcquiredOn { get; set; } = string.Empty;

    [Display(Name = "All trips amount")]
    public int TotalTripsCount { get; set; }

    public List<int> DriverIds { get; set; } = new ();

    [JsonIgnore]
    public List<int> ManagerIds { get; set; } = new ();

}