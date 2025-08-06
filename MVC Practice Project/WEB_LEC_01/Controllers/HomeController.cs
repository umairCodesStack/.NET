using Microsoft.AspNetCore.Mvc;
using WEB_LEC_01.Models;

namespace WEB_LEC_01.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //Product product = new Product 
            //{
            //    Name = "Test",
            //    Description = "Test",
            //    Id = 1
            //};
            //int id = 1;
            //ViewBag.CurrentTime=System.DateTime.Now;
            //ViewBag.Id= id;
            ////object data = "hello There";
           
            List<Product> products = new List<Product>
            {
                new Product{
                    Id = 1,
                    Name="Mobile",
                    Description="Samsung"
                },
                new Product
                {
                    Id = 2,
                    Name="PC",
                    Description="Intel"
                },
                new Product
                {
                    Id = 3,
                    Name="iPad",
                    Description="Apple"
                }
            };
            
            return View(products);
        }
        public ViewResult Student() 
        {
            string data = "Additional String";
            return View("Student",data); 
        }

        public ViewResult signup()
        {
            return View();
        }
    }
}
