namespace MotorPool.Domain;

public class Manager
{

    public int ManagerId { get; set; }

    public List<EnterpriseManager> EnterpriseLinks { get; set; } = new ();

    public bool OwnsEnterprise(int enterpriseId) => EnterpriseLinks.Any(link => link.EnterpriseId == enterpriseId);

}