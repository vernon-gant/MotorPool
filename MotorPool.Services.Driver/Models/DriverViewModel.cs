namespace MotorPool.Services.Drivers.Models;

public class DriverViewModel
{

    public int DriverId { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public decimal Salary { get; set; }

    public EnterpriseSummaryViewModel? EnterpriseLink { get; set; }

}

public class EnterpriseSummaryViewModel
{

    public int EnterpriseId { get; set; }

    public required string Name { get; set; }

    public required string VAT { get; set; }

    public int DriversCount { get; set; }

    public int VehiclesCount { get; set; }

}