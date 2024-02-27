namespace MotorPool.Abstractions;

public interface EnterpriseOwned
{

    public int? EnterpriseId { get; set; }

}

public interface ManagersOwned
{

    public List<int> ManagerIds { get; set; }

}