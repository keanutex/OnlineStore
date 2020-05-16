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
        public IActionResult addProduct(ProductModel product)
        {
            productAccessor.addProduct(product);
            return Ok();
        }

        [HttpGet("")]
        public IActionResult getProduct(int id)
        {
            return Ok(new { results = productAccessor.getProduct(id)});
        }

        [HttpDelete("")]
        public IActionResult removeProduct(int id)
        {
            productAccessor.removeProduct(id);
            return Ok();
        }

        [HttpPut("")]
        public IActionResult updateProduct(ProductModel product)
        {
            productAccessor.updateProduct(product);
            return Ok();
        }

    }
}