using EddTech.ConsoleApp.Domain;
using EddTech.ConsoleApp.Exceptions;
using EddTech.ConsoleApp.Patterns;
using EddTech.ConsoleApp.Repo;
using Xunit;

namespace EddTech.Tests;

public class SystemFacadeTests
{
    private SystemFacade _facade;

    public SystemFacadeTests()
    {
        var customerRepo = new InMemoryRepository<Customer>();
        var techRepo = new InMemoryRepository<Technician>();
        var jobRepo = new InMemoryRepository<RepairJob>();
        var supplierRepo = new InMemoryRepository<Supplier>();

        var notifier = new NotificationCenter(); // could inject a spy here
        IPricingStrategy pricing = new SimplePricingStrategy();

        _facade = new SystemFacade(customerRepo, techRepo, jobRepo, supplierRepo, notifier, pricing);
        _facade.SetAdmin(new Administrator("A1", "Admin"));
        _facade.RegisterCustomer(new Customer("C1", "Carla", "c@example.com", true));
        _facade.RegisterTechnician(new Technician("T1", "Tom", "Laptops"));
        _facade.CreateJob("J1", "C1", "E1", "T1");
    }

    [Fact]
    public void CostingAfterAssess_Succeeds()
    {
        _facade.TechnicianAssess("J1", new[] { new RepairTask("Screen fix", 2, 50) });
        var cost = _facade.AdminCostJob("J1");
        Assert.True(cost > 0);
    }

    [Fact]
    public void CostingBeforeAssess_Throws()
    {
        Assert.Throws<InvalidOperationForStateException>(() => _facade.AdminCostJob("J1"));
    }
}
