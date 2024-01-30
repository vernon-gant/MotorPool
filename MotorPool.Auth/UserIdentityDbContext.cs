using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MotorPool.Auth;

public class UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : IdentityDbContext<ApplicationUser>(options);