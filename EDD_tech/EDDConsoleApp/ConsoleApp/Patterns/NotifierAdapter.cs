using EddTech.ConsoleApp.Domain;

namespace EddTech.ConsoleApp.Patterns;

// Adapter that simulates an external Email API
public sealed class EmailNotifierAdapter : INotificationObserver
{
    public void OnJobUpdated(RepairJob job, string message)
    {
        // In real life: call SMTP/SendGrid/etc.
        Console.WriteLine($"[EMAIL] Job {job.JobId}: {message}");
    }
}
