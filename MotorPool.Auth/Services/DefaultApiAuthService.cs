using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MotorPool.Auth;

public class DefaultApiAuthService(UserManager<ApplicationUser> userManager, JWTConfig jwtConfig) : ApiAuthService
{

    public async ValueTask<AuthResult> LoginAsync(LoginDTO loginDTO)
    {
        var user = await userManager.FindByEmailAsync(loginDTO.Email);

        if (user == null) return AuthResult.Failure("User not found.");

        if (!await userManager.CheckPasswordAsync(user, loginDTO.Password)) return AuthResult.Failure("Invalid password.");

        List<Claim> claims = new ()
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Email, user.Email!)
        };
        var userClaims = await userManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);

        SymmetricSecurityKey key = new (Encoding.UTF8.GetBytes(jwtConfig.Key));
        SigningCredentials signingCredentials = new (key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new (jwtConfig.Issuer, jwtConfig.Audience, claims, expires: DateTime.Now.AddHours(2), signingCredentials: signingCredentials);

        return AuthResult.Success(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async ValueTask<AuthResult> RegisterAsync(RegisterDTO registerDTO)
    {
        if (registerDTO.Password != registerDTO.ConfirmPassword) return AuthResult.Failure("Passwords do not match.");

        var user = new ApplicationUser
        {
            Email = registerDTO.Email,
            UserName = registerDTO.UserName
        };

        var result = await userManager.CreateAsync(user, registerDTO.Password);

        if (!result.Succeeded) return AuthResult.Failure(result.Errors.Select(identityError => identityError.Description).First());

        return await LoginAsync(new LoginDTO { Email = registerDTO.Email, Password = registerDTO.Password });
    }

    public async ValueTask<UserViewModel> GetUserAsync(string userId)
    {
        var user = (await userManager.FindByIdAsync(userId))!;

        var claims = await userManager.GetClaimsAsync(user);

        var managerId = claims.FirstOrDefault(claim => claim.Type == "ManagerId")?.Value;

        return new UserViewModel
        {
            UserName = user.UserName!,
            Email = user.Email!,
            ManagerId = managerId == null ? null : int.Parse(managerId)
        };
    }

}