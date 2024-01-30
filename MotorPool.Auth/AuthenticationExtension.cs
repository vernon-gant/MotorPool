using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MotorPool.Auth;

public static class AuthenticationExtension
{

    public static void AddMotorPoolAuthentication(this IServiceCollection services, string connectionString)
    {
        services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 8;
                })
                .AddEntityFrameworkStores<UserIdentityDbContext>()
                .AddDefaultTokenProviders();

        services.AddDbContext<UserIdentityDbContext>(options => options.UseSqlServer(connectionString));
    }

}