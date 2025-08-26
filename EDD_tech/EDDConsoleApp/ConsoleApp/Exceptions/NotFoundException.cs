namespace EddTech.ConsoleApp.Exceptions;

public sealed class NotFoundException : DomainException
{
    public NotFoundException(string type, string id) : base($"{type} with id '{id}' not found") { }
}
