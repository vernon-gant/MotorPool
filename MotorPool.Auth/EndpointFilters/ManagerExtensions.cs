using System.Security.Claims;

namespace MotorPool.Auth.EndpointFilters;

public static class ManagerExtensions
{

    public static bool IsManager(this ClaimsPrincipal user) => user.Claims.Any(c => c.Type == "ManagerId");

    public static int GetManagerId(this ClaimsPrincipal user) => int.Parse(user.Claims.First(c => c.Type == "ManagerId").Value);

}