using Lec_24_Oct.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Lec_24_Oct.Controllers
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
			object message = string.Empty;
			if (HttpContext.Request.Cookies.ContainsKey("First_visit_date_time"))
			{
				message = "You Visted at " + HttpContext.Request.Cookies["First_visit_date_time"];
			}
			else
			{
				CookieOptions op = new CookieOptions();
				op.Secure = true;
				op.Expires = DateTime.Now.AddDays(1);
				HttpContext.Response.Cookies.Append("First_visit_date_time",
				System.DateTime.Now.ToString(), op);
				message = "You Visited us for First Time";
			}
			return View(message);
		}
	}
}
