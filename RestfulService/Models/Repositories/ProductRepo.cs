using RestfulService.Models.Interfaces;

namespace RestfulService.Models.Repositories
{
	public class ProductRepo:IProductRepo
	{
		List<Product> products = new List<Product>()
			{ new Product{Id = 1, Name = "Ammar"}
			};

		void IProductRepo.Add(Product product)
		{
			products.Append(product);
		}

		void IProductRepo.Delete(int id)
		{
			Product product = GetProductById(id);
			products.Remove(product);
		}

		List<Product> IProductRepo.GetAllProduct()
		{
			return products;
		}

		public Product GetProductById(int id)
		{
			//Product product = new Product();
			//for (int i = 0; i < products.Count; i++)
			//{
			//	if (products[i].Id == id)
			//	{
			//		return products[i];
			//	}
			//}
			//return null ;
			return products.Where(p => p.Id == id).Single();
		}

		void IProductRepo.Update(Product product)
		{
			throw new NotImplementedException();
		}
	}
}
