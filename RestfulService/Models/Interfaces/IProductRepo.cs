namespace RestfulService.Models.Interfaces
{
	public interface IProductRepo
	{
		void Add(Product product);
		void Update(Product product);
		void Delete(int id);
		List<Product> GetAllProduct();
		Product GetProductById(int id);
	}
}
