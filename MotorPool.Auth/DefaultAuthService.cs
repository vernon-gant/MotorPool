using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace MotorPool.Auth;

public class DefaultAuthService(UserManager<ApplicationUser> userManager, JWTConfig jwtConfig) : AuthService
{

    public async ValueTask<AuthResult> LoginAsync(LoginDTO loginDTO)
    {
        ApplicationUser? user = await userManager.FindByEmailAsync(loginDTO.Email);

        if (user == null) return AuthResult.Failure("User not found.");

        if (!await userManager.CheckPasswordAsync(user, loginDTO.Password)) return AuthResult.Failure("Invalid password.");

        List<Claim> claims = new ()
        {
            new (ClaimTypes.NameIdentifier, user.Id),
            new (ClaimTypes.Name, user.UserName!),
            new (ClaimTypes.Email, user.Email!)
        };
        IList<Claim> userClaims = await userManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);

        SymmetricSecurityKey key = new (Encoding.UTF8.GetBytes(jwtConfig.Key));
        SigningCredentials signingCredentials = new (key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new (jwtConfig.Issuer, jwtConfig.Audience, claims, expires: DateTime.Now.AddHours(2), signingCredentials: signingCredentials);

        return AuthResult.Success(new JwtSecurityTokenHandler().WriteToken(token));
    }

    public async ValueTask<AuthResult> RegisterAsync(RegisterDTO registerDTO)
    {
        if (registerDTO.Password != registerDTO.ConfirmPassword) return AuthResult.Failure("Passwords do not match.");

        ApplicationUser user = new ApplicationUser
        {
            Email = registerDTO.Email,
            UserName = registerDTO.UserName,
        };

        IdentityResult result = await userManager.CreateAsync(user, registerDTO.Password);

        if (!result.Succeeded) return AuthResult.Failure(result.Errors.Select(identityError => identityError.Description).First());

        return await LoginAsync(new LoginDTO { Email = registerDTO.Email, Password = registerDTO.Password });
    }


}