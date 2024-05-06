namespace MotorPool.Repository.Vehicle;

public class VehicleQueryOptions
{

    public int? EnterpriseId { get; set; }

    public int? VehicleBrandId { get; set; }

    public int? ManagerId { get; set; }

}

public static class VehicleQueryBuilder
{

    public static IQueryable<Domain.Vehicle> WithQueryOptions(this IQueryable<Domain.Vehicle> query, VehicleQueryOptions? queryOptions)
    {
        if (queryOptions?.VehicleBrandId != null) query = query.Where(vehicle => vehicle.VehicleBrandId == queryOptions.VehicleBrandId);

        if (queryOptions?.EnterpriseId != null) query = query.Where(vehicle => vehicle.EnterpriseId == queryOptions.EnterpriseId);

        if (queryOptions?.ManagerId != null) query = query.Where(vehicle => vehicle.Enterprise != null && vehicle.Enterprise.ManagerLinks.Any(link => link.ManagerId == queryOptions.ManagerId));

        return query;
    }

}