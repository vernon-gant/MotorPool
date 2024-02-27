using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MotorPool.Auth.Manager;

namespace MotorPool.Auth;

public static class AuthorizationServiceCollectionExtension
{

    public static void AddAuthorization(this IServiceCollection services, string connectionString)
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

        services.AddAuthorization(options =>
        {
            options.AddPolicy("IsManager", policy => policy.RequireClaim("ManagerId"));

            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .RequireClaim("ManagerId")
                                    .Build();
        });
    }

}