﻿using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class Enterprise
{

    [Key]
    public int EnterpriseId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(100)]
    public string City { get; set; } = null!;

    [MaxLength(100)]
    public string Street { get; set; } = null!;

    [MaxLength(100)]
    public string VAT { get; set; } = null!;

    public DateTime FoundedOn { get; set; }

    public List<Vehicle> Vehicles { get; set; } = new ();

    public List<Driver> Drivers { get; set; } = new ();

    public List<EnterpriseManager> ManagerLinks { get; set; } = new ();

}