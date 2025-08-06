using Cookies_Lec.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cookies_Lec.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			List<Products> products = new List<Products>
			{
				new Products
				{
					Id=1,
					Name="PC"
				},
				new Products
				{
					Id = 2,
					Name="Mobile"
				}
			};

			return View(products);
			
		}
        public IActionResult AddToCart(int MyId)
        {
            object message = string.Empty;
            if (HttpContext.Request.Cookies.ContainsKey("Id"))
            {
                message = "You Visted at " + HttpContext.Request.Cookies["Id"];
            }
            else
            {
                CookieOptions op = new CookieOptions();
                op.Secure = true;
                op.Expires = DateTime.Now.AddDays(1);
                HttpContext.Response.Cookies.Append("Id",
                MyId.ToString(), op);
                message = "No Product Selected";
            }
            // Return the message to the AddToCart view
            return View(message);
        }


        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
