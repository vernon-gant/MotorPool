using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MotorPool.UI.Areas.Identity.Data;

public class UserIdentityContext(DbContextOptions<UserIdentityContext> options) : IdentityDbContext<IdentityUser>(options);
