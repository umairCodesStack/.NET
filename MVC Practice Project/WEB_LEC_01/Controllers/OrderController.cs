using Microsoft.AspNetCore.Mvc;

namespace WEB_LEC_01.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
