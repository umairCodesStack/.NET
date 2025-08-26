using EddTech.ConsoleApp.Domain;
using EddTech.ConsoleApp.Menu;
using EddTech.ConsoleApp.Patterns;
using EddTech.ConsoleApp.Repo;


var customerRepo = new InMemoryRepository<Customer>();
var techRepo = new InMemoryRepository<Technician>();
var jobRepo = new InMemoryRepository<RepairJob>();
var supplierRepo = new InMemoryRepository<Supplier>();

var notifier = new NotificationCenter();
notifier.Subscribe(new EmailNotifierAdapter()); // Observer + Adapter

IPricingStrategy pricing = new SimplePricingStrategy(); // Strategy
var facade = new SystemFacade(customerRepo, techRepo, jobRepo, supplierRepo, notifier, pricing);

Seed(facade);
var menu = new ConsoleMenu(facade);
menu.Run();

static void Seed(SystemFacade f)
{
    f.SetAdmin(new Administrator("A1", "Eve Admin"));
    f.RegisterTechnician(new Technician("T1", "Tom Tech", "Laptops"));
    f.RegisterTechnician(new Technician("T2", "Tina Tech", "Mobiles"));
    f.RegisterCustomer(new Customer("C1", "Carla Customer", "carla@example.com", registered: true));
    f.RegisterCustomer(new Customer("C2", "Waqas Walkin", "waqas@example.com", registered: false));
    f.AddSupplier(new Supplier("S1", "Partz Co.", "Cardiff"));
}
