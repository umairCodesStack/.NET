using EddTech.ConsoleApp.Domain;

namespace EddTech.ConsoleApp.Patterns;

public interface INotificationObserver
{
    void OnJobUpdated(RepairJob job, string message);
}

public sealed class NotificationCenter
{
    private readonly List<INotificationObserver> _observers = new();
    public void Subscribe(INotificationObserver o) => _observers.Add(o);
    public void Unsubscribe(INotificationObserver o) => _observers.Remove(o);
    public void NotifyAll(RepairJob job, string message)
    {
        foreach (var o in _observers) o.OnJobUpdated(job, message);
    }
}
