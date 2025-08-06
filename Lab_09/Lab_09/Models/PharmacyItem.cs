namespace Lab_09.Models
{
	public class PharmacyItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Catagorey { get; set; }
		public decimal Price {  get; set; }
		public int Quantity {  get; set; }
		public string ImagePath {  get; set; }
	}
}
