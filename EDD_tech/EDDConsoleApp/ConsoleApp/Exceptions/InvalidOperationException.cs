namespace EddTech.ConsoleApp.Exceptions;

public sealed class InvalidOperationForStateException : DomainException
{
    public InvalidOperationForStateException(string msg) : base(msg) { }
}
