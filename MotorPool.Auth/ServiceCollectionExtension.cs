using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MotorPool.Auth;

public static class ServiceCollectionExtension
{

    public static void AddAuthServices(this IServiceCollection services, string connectionString)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;

                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AuthDbContext>()
                .AddDefaultTokenProviders();

        services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<ApiAuthService, DefaultApiAuthService>();
    }

}