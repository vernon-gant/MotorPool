using System.ComponentModel.DataAnnotations;

namespace MotorPool.Domain;

public class Driver
{

    [Key]
    public int DriverId { get; set; }

    [MaxLength(100)]
    public string FirstName { get; set; } = null!;

    [MaxLength(100)]
    public string LastName { get; set; } = null!;

    public decimal Salary { get; set; }

    public EnterpriseDriver? EnterpriseLink { get; set; }

}