using Microsoft.AspNetCore.Mvc;

namespace WEB_LEC_01.Controllers
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
