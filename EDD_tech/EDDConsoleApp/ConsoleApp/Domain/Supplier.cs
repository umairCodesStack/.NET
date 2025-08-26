namespace EddTech.ConsoleApp.Domain;

public sealed class Supplier
{
    public string Id { get; }
    public string Name { get; }
    public string Location { get; }

    public Supplier(string id, string name, string location)
    { Id = id; Name = name; Location = location; }
}
