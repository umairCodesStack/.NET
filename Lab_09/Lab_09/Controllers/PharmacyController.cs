using Lab_09.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_09.Controllers
{
	public class PharmacyController : Controller
	{
		private readonly IPharmacyService _pharmacyService;

		// Constructor injection
		public PharmacyController(IPharmacyService pharmacyService)
		{
			_pharmacyService = pharmacyService;
		}

		public IActionResult Index()
		{
			var items = _pharmacyService.GetAllItems();
			return View(items);
		}

		public IActionResult Details(int id)
		{
			var item = _pharmacyService.GetItemById(id);
			if (item == null)
				return NotFound();
			return View(item);
		}

		[HttpPost]
		public IActionResult AddItem(PharmacyItem newItem)
		{
			_pharmacyService.AddItem(newItem);
			return RedirectToAction("Index");
		}
	}
}
