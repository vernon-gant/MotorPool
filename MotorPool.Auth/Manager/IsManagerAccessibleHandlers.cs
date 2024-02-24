using Microsoft.AspNetCore.Authorization;

using MotorPool.Services.Drivers.Models;
using MotorPool.Services.Enterprise.Models;
using MotorPool.Services.Vehicles.Models;

namespace MotorPool.Auth;

public class IsManagerAccessibleVehicleHandler : AuthorizationHandler<IsManagerAccessibleRequirement, VehicleViewModel>
{

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsManagerAccessibleRequirement requirement, VehicleViewModel vehicleViewModel)
    {
        var managerId = int.Parse(context.User.FindFirst("ManagerId")!.Value);

        if (vehicleViewModel.ManagerIds.Contains(managerId)) context.Succeed(requirement);
        else context.Fail();

        return Task.CompletedTask;
    }

}

public class IsManagerAccessibleEnterpriseHandler : AuthorizationHandler<IsManagerAccessibleRequirement, EnterpriseViewModel>
{

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsManagerAccessibleRequirement requirement, EnterpriseViewModel enterpriseViewModel)
    {
        var managerId = int.Parse(context.User.FindFirst("ManagerId")!.Value);

        if (enterpriseViewModel.ManagerIds.Contains(managerId)) context.Succeed(requirement);
        else context.Fail();

        return Task.CompletedTask;
    }

}

public class IsManagerAccessibleDriverHandler : AuthorizationHandler<IsManagerAccessibleRequirement, DriverViewModel>
{

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsManagerAccessibleRequirement requirement, DriverViewModel driverViewModel)
    {
        var managerId = int.Parse(context.User.FindFirst("ManagerId")!.Value);

        if (driverViewModel.ManagerIds.Contains(managerId)) context.Succeed(requirement);
        else context.Fail();

        return Task.CompletedTask;
    }

}