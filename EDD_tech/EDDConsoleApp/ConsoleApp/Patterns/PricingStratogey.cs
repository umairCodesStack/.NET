using EddTech.ConsoleApp.Domain;

namespace EddTech.ConsoleApp.Patterns;

public interface IPricingStrategy
{
    double Calculate(IEnumerable<RepairTask> tasks);
}
