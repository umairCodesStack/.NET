using EddTech.ConsoleApp.Domain;
using EddTech.ConsoleApp.Exceptions;
using EddTech.ConsoleApp.Patterns;

namespace EddTech.ConsoleApp.Menu;

public sealed class ConsoleMenu
{
    private readonly SystemFacade _facade;
    public ConsoleMenu(SystemFacade facade) => _facade = facade;

    public void Run()
    {
        Console.WriteLine("Welcome to EDD Technologies Prototype\n");
        while (true)
        {
            try
            {
                Console.WriteLine("Select role: 1) Admin  2) Technician  3) Customer  0) Exit");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AdminMenu(); break;
                    case "2": TechMenu(); break;
                    case "3": CustomerMenu(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
            catch (DomainException ex) { Console.WriteLine($"[ERROR] {ex.Message}"); }
            catch (Exception ex) { Console.WriteLine($"[UNEXPECTED] {ex.Message}"); }
        }
    }

    private void AdminMenu()
    {
        Console.WriteLine("-- Admin -- 1) Create Job 2) Cost Job 3) Mark Ready 4) Dispatch 5) Add Supplier 6) List Jobs 7) Reassign Job 0) Back");
        var c = Console.ReadLine();
        switch (c)
        {
            case "1":
                Console.Write("JobId: "); var j = Console.ReadLine()!;
                Console.Write("CustomerId: "); var cid = Console.ReadLine()!;
                Console.Write("EquipmentId: "); var eid = Console.ReadLine()!;
                Console.Write("TechnicianId: "); var tid = Console.ReadLine()!;
                _facade.CreateJob(j, cid, eid, tid);
                Console.WriteLine("Job created.");
                break;
            case "2":
                Console.Write("JobId: "); var j2 = Console.ReadLine()!;
                var cost = _facade.AdminCostJob(j2);
                Console.WriteLine($"Total: £{cost:0.00}");
                break;
            case "3":
                Console.Write("JobId: "); var j3 = Console.ReadLine()!;
                _facade.MarkReady(j3);
                Console.WriteLine("Marked ready.");
                break;
            case "4":
                Console.Write("JobId: "); var j4 = Console.ReadLine()!;
                _facade.Dispatch(j4);
                Console.WriteLine("Dispatched.");
                break;
            case "5":
                Console.Write("Supplier Id: "); var sid = Console.ReadLine()!;
                Console.Write("Name: "); var sn = Console.ReadLine()!;
                Console.Write("Location: "); var sl = Console.ReadLine()!;
                _facade.AddSupplier(new Supplier(sid, sn, sl));
                Console.WriteLine("Supplier added.");
                break;
            case "6":
                foreach (var job in _facade.ListJobs())
                    Console.WriteLine($"{job.JobId} - {job.Status} (Tech: {job.TechnicianId})");
                break;
            case "7":
                Console.Write("JobId: "); var j7 = Console.ReadLine()!;
                Console.Write("New Tech Id: "); var t7 = Console.ReadLine()!;
                _facade.AssignJob(j7, t7);
                Console.WriteLine("Reassigned.");
                break;
            case "0": break;
            default: Console.WriteLine("Invalid"); break;
        }
    }

    private void TechMenu()
    {
        Console.WriteLine("-- Technician -- 1) Assess Job 0) Back");
        var c = Console.ReadLine();
        if (c == "1")
        {
            Console.Write("JobId: "); var j = Console.ReadLine()!;
            Console.Write("Task description: "); var d = Console.ReadLine()!;
            Console.Write("Hours: "); var h = double.Parse(Console.ReadLine()!);
            Console.Write("Part cost: "); var p = double.Parse(Console.ReadLine()!);
            _facade.TechnicianAssess(j, new[] { new RepairTask(d, h, p) });
            Console.WriteLine("Assessed.");
        }
    }

    private void CustomerMenu()
    {
        Console.WriteLine("-- Customer -- 1) Upgrade to Registered 2) Flag Non-Paying (Admin/Tech) 0) Back");
        var c = Console.ReadLine();
        switch (c)
        {
            case "1":
                Console.Write("CustomerId: "); var id = Console.ReadLine()!;
                // For brevity: simulate retrieval & upgrade (would store back in repo in a full impl)
                Console.WriteLine($"Customer {id} upgraded (simulated).");
                break;
            case "2":
                Console.Write("CustomerId: "); var id2 = Console.ReadLine()!;
                Console.WriteLine($"Customer {id2} flagged (simulated).");
                break;
        }
    }
}
