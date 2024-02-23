using System.Security.Claims;

namespace MotorPool.Auth;

public static class IsManagerExtension
{

    public static bool IsManager(this ClaimsPrincipal user) => user.Claims.Any(c => c.Type == "ManagerId");

}