using Microsoft.AspNetCore.Mvc;

namespace WEB_LEC_01.Controllers
{
    public class Student : Controller
    {
        public ViewResult Index()
        {

            return View();
        }
        [HttpGet]
        public ViewResult StudentForm() 
        {
            return View();
        }
        [HttpPost]
        public ViewResult StudentForm(string name,string age,string cgpa ,string semester) 
        {
            return View();
        }
    }
}
