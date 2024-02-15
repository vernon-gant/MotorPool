using System.ComponentModel.DataAnnotations;

namespace MotorPool.Auth;

public class LoginDTO
{

    [EmailAddress]
    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

}