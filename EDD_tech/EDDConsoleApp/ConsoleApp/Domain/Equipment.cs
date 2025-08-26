namespace EddTech.ConsoleApp.Domain;

public sealed class Equipment
{
    public string Id { get; }
    public string Type { get; }
    public string Model { get; }

    public Equipment(string id, string type, string model)
    { Id = id; Type = type; Model = model; }
}
