using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product> 
            {
                new Product{Name="P1",Description="C1"},
                new Product{Name="P2",Description="C2"}
            };
            var query = products.Where(s => s.Name.StartsWith("P"))
                                .Select(p => new { Name = p.Name, Description = p.Description });
           // var data=_context.Catagoery.Where(s => s.Name.Equals("Electronics").Products.ToList();
           //syntax that join two tables and get productts

            foreach (var product in query) 
            {
                Console.WriteLine($"Name: {product.Name} \n Description: {product.Description}");
            }


                
        }
    }
}
