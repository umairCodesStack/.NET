namespace EddTech.ConsoleApp.Domain;

public sealed class RepairJob
{
    public string JobId { get; }
    public string CustomerId { get; }
    public string EquipmentId { get; }
    public string TechnicianId { get; private set; }
    public JobStatus Status { get; private set; } = JobStatus.JobCreated;
    private readonly List<RepairTask> _tasks = new();

    public IReadOnlyList<RepairTask> Tasks => _tasks;

    public RepairJob(string jobId, string customerId, string equipmentId, string technicianId)
    {
        JobId = jobId; CustomerId = customerId; EquipmentId = equipmentId; TechnicianId = technicianId;
    }

    public void AssignTech(string technicianId) => TechnicianId = technicianId;
    public void AddTask(RepairTask task) => _tasks.Add(task);
    public void SetStatus(JobStatus s) => Status = s;
}
