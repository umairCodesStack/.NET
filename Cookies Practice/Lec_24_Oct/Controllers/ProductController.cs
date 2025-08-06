using Microsoft.AspNetCore.Mvc;
using Lec_24_Oct.Models;
using System.IO;

namespace Lec_24_Oct.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Products()
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
		[HttpPost]
        public IActionResult AddToCart(int MyId)
        {
			if (HttpContext.Session.Keys.Contains("Product")) 
			{

			}
			return View("Products");
        }
		public IActionResult ViewCart() 
		{
			return View();
		}


    }
}
