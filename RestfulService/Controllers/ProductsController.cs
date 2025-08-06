using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulService.Models;
using RestfulService.Models.Interfaces;
using System.Reflection.Metadata;

namespace RestfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet(Name = "GetProducts")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_productRepo.GetAllProduct());
        }
        [HttpGet]
        [Route("GetById /{id}")]
        public ActionResult<Product> GetById(int id)
        {
            try
            {
                return Ok(_productRepo.GetProductById(id));
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }
        [HttpPost]
        [Route("CreateProduct")]
        public ActionResult<Product>Create(Product product)
        {
            _productRepo.Add(product);
            return CreatedAtAction(nameof(GetById), new { Id = product.Id, Name = product.Name });
        }
    }
}
