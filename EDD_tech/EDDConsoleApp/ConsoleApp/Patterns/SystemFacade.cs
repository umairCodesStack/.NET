using EddTech.ConsoleApp.Domain;
using EddTech.ConsoleApp.Exceptions;
using EddTech.ConsoleApp.Repo;

namespace EddTech.ConsoleApp.Patterns;

public sealed class SystemFacade
{
    private readonly IRepository<Customer> _customers;
    private readonly IRepository<Technician> _techs;
    private readonly IRepository<RepairJob> _jobs;
    private readonly IRepository<Supplier> _suppliers;
    private readonly NotificationCenter _notifier;
    private readonly IPricingStrategy _pricing;
    private readonly JobFactory _factory = new DefaultJobFactory();
    private Administrator? _admin;

    public SystemFacade(
        IRepository<Customer> customers,
        IRepository<Technician> techs,
        IRepository<RepairJob> jobs,
        IRepository<Supplier> suppliers,
        NotificationCenter notifier,
        IPricingStrategy pricing)
    {
        _customers = customers; _techs = techs; _jobs = jobs; _suppliers = suppliers;
        _notifier = notifier; _pricing = pricing;
    }

    public void SetAdmin(Administrator admin) => _admin = admin;

    public void RegisterCustomer(Customer c) => _customers.Save(c.Id, c);
    public void RegisterTechnician(Technician t) => _techs.Save(t.Id, t);
    public void AddSupplier(Supplier s) => _suppliers.Save(s.Id, s);
    public IReadOnlyList<Supplier> ListSuppliers() => _suppliers.FindAll();

    public RepairJob CreateJob(string jobId, string customerId, string equipmentId, string technicianId)
    {
        EnsureCustomer(customerId);
        EnsureTech(technicianId);
        var job = _factory.Create(jobId, customerId, equipmentId, technicianId);
        _jobs.Save(jobId, job);
        _notifier.NotifyAll(job, "Job Created");
        return job;
    }

    public void AssignJob(string jobId, string technicianId)
    {
        var job = GetJob(jobId);
        EnsureTech(technicianId);
        job.AssignTech(technicianId);
        _notifier.NotifyAll(job, $"Job Reassigned to Tech {technicianId}");
    }

    public void TechnicianAssess(string jobId, IEnumerable<RepairTask> tasks)
    {
        var job = GetJob(jobId);
        if (job.Status != JobStatus.JobCreated)
            throw new InvalidOperationForStateException("Job must be in 'JobCreated' to assess");
        foreach (var t in tasks) job.AddTask(t);
        job.SetStatus(JobStatus.JobAssessed);
        _notifier.NotifyAll(job, "Job Assessed");
    }

    public double AdminCostJob(string jobId)
    {
        var job = GetJob(jobId);
        if (job.Status != JobStatus.JobAssessed)
            throw new InvalidOperationForStateException("Job must be assessed before costing");
        var cost = _pricing.Calculate(job.Tasks);
        _notifier.NotifyAll(job, $"Quote ready: £{cost:0.00}");
        return cost;
    }

    public void MarkReady(string jobId)
    {
        var job = GetJob(jobId);
        job.SetStatus(JobStatus.ReadyForCollection);
        _notifier.NotifyAll(job, "Equipment ready for collection");
    }

    public void Dispatch(string jobId)
    {
        var job = GetJob(jobId);
        job.SetStatus(JobStatus.Dispatched);
        _notifier.NotifyAll(job, "Dispatched");
    }

    public IReadOnlyList<RepairJob> ListJobs() => _jobs.FindAll();

    private RepairJob GetJob(string jobId) =>
        _jobs.FindById(jobId) ?? throw new NotFoundException("Job", jobId);

    private void EnsureCustomer(string id)
    {
        _ = _customers.FindById(id) ?? throw new NotFoundException("Customer", id);
    }
    private void EnsureTech(string id)
    {
        _ = _techs.FindById(id) ?? throw new NotFoundException("Technician", id);
    }
}
