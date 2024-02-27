using System.Security.Claims;

namespace MotorPool.Auth.Manager;

public static class ManagerExtensions
{

    public static bool IsManager(this ClaimsPrincipal user)
    {
        return user.Claims.Any(c => c.Type == "ManagerId");
    }

    public static bool IsAdmin(this ClaimsPrincipal user)
    {
        return user.Claims.Any(c => c.Type == "AdminId");
    }

    public static int GetManagerId(this ClaimsPrincipal user)
    {
        return int.Parse(user.Claims.First(c => c.Type == "ManagerId").Value);
    }

}