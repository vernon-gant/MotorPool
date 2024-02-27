using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using MotorPool.Auth;

namespace MotorPool.API.Endpoints;

public static class AuthEndpoints
{

    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("login", async (ApiAuthService authService, LoginDTO loginDTO) =>
        {
            var result = await authService.LoginAsync(loginDTO);

            return result.IsSuccess
                ? Results.Ok(new { result.Token })
                : Results.Problem(new ProblemDetails
                {
                    Title = "Login failed",
                    Status = 400,
                    Detail = result.Error
                });
        });

        app.MapPost("register", async (ApiAuthService authService, RegisterDTO registerDTO) =>
        {
            var result = await authService.RegisterAsync(registerDTO);

            return result.IsSuccess
                ? Results.Ok(new { result.Token })
                : Results.Problem(new ProblemDetails
                {
                    Title = "Registration failed",
                    Status = 400,
                    Detail = result.Error
                });
        });

        app.MapGet("me", async (ApiAuthService authService, ClaimsPrincipal principal) =>
           {
               var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

               if (userId == null) return Results.Unauthorized();

               return Results.Ok(await authService.GetUserAsync(userId));
           })
           .RequireAuthorization()
           .Produces<UserViewModel>();
    }

}