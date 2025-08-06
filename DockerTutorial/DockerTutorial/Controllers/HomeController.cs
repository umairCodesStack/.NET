using DockerTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DockerTutorial.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _Context;


        public HomeController(AppDbContext  context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Student() 
        {
            List<Student> students = _Context.Students.ToList();
            
            return View(students);
        }
        public IActionResult AddStudent()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _Context.Students.Add(student);
            _Context.SaveChanges();
            return RedirectToAction("Student");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
