using MotorPool.Domain;

namespace MotorPool.Services.Manager;

public static class ManagerLINQExtension
{

    public static IQueryable<Vehicle> ForManager(this IQueryable<Vehicle> vehicles, int managerId) =>
        vehicles.Where(vehicle => vehicle.Enterprise != null && vehicle.Enterprise.ManagerLinks.Any(managerLink => managerLink.ManagerId == managerId));

    public static IQueryable<Driver> ForManager(this IQueryable<Driver> drivers, int managerId) =>
        drivers.Where(driver => driver.Enterprise != null && driver.Enterprise.ManagerLinks.Any(managerLink => managerLink.ManagerId == managerId));

    public static IQueryable<Domain.Enterprise> ForManager(this IQueryable<Domain.Enterprise> enterprises, int managerId) =>
        enterprises.Where(enterprise => enterprise.ManagerLinks.Any(managerLink => managerLink.ManagerId == managerId));

}