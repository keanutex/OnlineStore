using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    [Route("products/")]
    [ApiController]
    public class ProductsController: Controller
    {
        private readonly IProductAccessor productAccessor;

        public ProductsController(IProductAccessor productAccessor)
        {
            this.productAccessor = productAccessor;
        }

        [HttpPost("")]
        public IActionResult AddProduct(ProductModel product)
        {
            productAccessor.AddProduct(product);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(productAccessor.GetProduct(id));
        }

        [HttpGet("all/")]
        public IActionResult GetAllProducts()
        {
            return Ok(productAccessor.GetAllProducts());
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            productAccessor.RemoveProduct(id);
            return Ok();
        }

        [HttpPut("")]
        public IActionResult UpdateProduct(ProductModel product)
        {
            productAccessor.UpdateProduct(product);
            return Ok();
        }

    }
}