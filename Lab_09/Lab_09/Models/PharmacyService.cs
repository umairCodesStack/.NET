using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Lab_09.Models
{
	public class PharmacyService : IPharmacyService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public PharmacyService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		private ISession Session => _httpContextAccessor.HttpContext.Session;

		// Implementation of GetAllItems
		public List<PharmacyItem> GetAllItems()
		{
			List<PharmacyItem> items = new List<PharmacyItem>();
			if (Session.Keys.Contains("items"))
			{
				string json = Session.GetString("items");
				items = JsonSerializer.Deserialize<List<PharmacyItem>>(json);
			}
			return items;
		}

		// Implementation of GetItemById
		public PharmacyItem GetItemById(int id)
		{
			List<PharmacyItem> items = GetAllItems();
			return items.FirstOrDefault(item => item.Id == id);
		}

		// Implementation of AddItem
		public void AddItem(PharmacyItem item)
		{
			List<PharmacyItem> items = GetAllItems();
			items.Add(item);

			string updatedItemsJson = JsonSerializer.Serialize(items);
			Session.SetString("items", updatedItemsJson);
		}
	}
}
