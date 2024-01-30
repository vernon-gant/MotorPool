using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;

namespace MotorPool.Auth;

public class ApplicationUser : IdentityUser
{

    [PersonalData]
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;

}