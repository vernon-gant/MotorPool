using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using MotorPool.Auth;

namespace MotorPool.API.Endpoints;

public static class AuthEndpoints
{

    public static void MapAuthEndpoints(this WebApplication app)
    {
        RouteGroupBuilder authGroupBuilder = app.MapGroup("auth");

        authGroupBuilder.MapPost("login", Login)
                        .Produces<LoginDTO>()
                        .Produces(StatusCodes.Status200OK)
                        .Produces(StatusCodes.Status400BadRequest);

        authGroupBuilder.MapPost("register", Register)
                        .Produces<RegisterDTO>()
                        .Produces(StatusCodes.Status200OK)
                        .Produces(StatusCodes.Status400BadRequest);

        authGroupBuilder.MapGet("me", Me)
                        .RequireAuthorization()
                        .Produces(StatusCodes.Status200OK)
                        .Produces(StatusCodes.Status401Unauthorized)
                        .Produces<UserViewModel>();
    }

    private static async Task<IResult> Login(ApiAuthService authService, LoginDTO loginDTO)
    {
        AuthResult result = await authService.LoginAsync(loginDTO);

        return result.IsSuccess
            ? Results.Ok(new { result.Token })
            : Results.Problem(new ProblemDetails
            {
                Title = "Login failed",
                Status = 400,
                Detail = result.Error
            });
    }

    private static async Task<IResult> Register(ApiAuthService authService, RegisterDTO registerDTO)
    {
        AuthResult result = await authService.RegisterAsync(registerDTO);

        return result.IsSuccess
            ? Results.Ok(new { result.Token })
            : Results.Problem(new ProblemDetails
            {
                Title = "Registration failed",
                Status = 400,
                Detail = result.Error
            });
    }

    private static async Task<IResult> Me(ApiAuthService authService, ClaimsPrincipal principal)
    {
        string? userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null) return Results.Unauthorized();

        return Results.Ok(await authService.GetUserAsync(userId));
    }

}