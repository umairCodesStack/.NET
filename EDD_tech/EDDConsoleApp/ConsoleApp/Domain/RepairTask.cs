namespace EddTech.ConsoleApp.Domain;

public sealed class RepairTask
{
    public string Description { get; }
    public double Hours { get; }
    public double PartCost { get; }

    public RepairTask(string description, double hours, double partCost)
    { Description = description; Hours = hours; PartCost = partCost; }
}
