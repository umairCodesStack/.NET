using EddTech.ConsoleApp.Domain;

namespace EddTech.ConsoleApp.Patterns;

public abstract class JobFactory
{
    public abstract RepairJob Create(string jobId, string customerId, string equipmentId, string technicianId);
}

public sealed class DefaultJobFactory : JobFactory
{
    public override RepairJob Create(string jobId, string customerId, string equipmentId, string technicianId)
        => new(jobId, customerId, equipmentId, technicianId);
}
