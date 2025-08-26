using EddTech.ConsoleApp.Domain;

namespace EddTech.ConsoleApp.Patterns;

public sealed class SimplePricingStrategy : IPricingStrategy
{
    private const double LabourRatePerHour = 40.0;
    public double Calculate(IEnumerable<RepairTask> tasks) =>
        tasks.Sum(t => t.PartCost + t.Hours * LabourRatePerHour);
}
