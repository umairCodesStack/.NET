namespace EddTech.ConsoleApp.Domain;

public abstract class User
{
    public string Id { get; }
    public string Name { get; protected set; }
    protected User(string id, string name) { Id = id; Name = name; }
}

public sealed class Administrator : User
{
    public Administrator(string id, string name) : base(id, name) { }
}

public sealed class Technician : User
{
    public string Expertise { get; }
    public Technician(string id, string name, string expertise) : base(id, name) => Expertise = expertise;
}

public sealed class Customer : User
{
    public string Email { get; private set; }
    public bool Registered { get; private set; }
    public bool IsFlaggedNonPaying { get; private set; }

    public Customer(string id, string name, string email, bool registered)
        : base(id, name) { Email = email; Registered = registered; }

    public void Upgrade() => Registered = true;
    public void FlagNonPaying() => IsFlaggedNonPaying = true;
}
