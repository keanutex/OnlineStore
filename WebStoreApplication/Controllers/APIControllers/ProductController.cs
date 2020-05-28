using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    [Route("products/")]
    [ApiController]
    public class ProductsController: Controller
    {
        private readonly IAccessDBContext dbAccessor;

        public ProductsController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }

        [HttpPost("")]
        public IActionResult AddProduct(ProductModel product)
        {
            if (dbAccessor.AddProduct(product) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(dbAccessor.GetProduct(id));
        }

        [HttpGet("all/")]
        public IActionResult GetAllProducts()
        {
            return Ok(dbAccessor.GetAllProducts());
        }

        [HttpGet("all/user/{id}")]
        public IActionResult GetAllUserProducts(int id)
        {
            return Ok(dbAccessor.GetAllUserProducts(id));
        }

        
        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            if (dbAccessor.RemoveProduct(id) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, ProductModel product)
        {
            if (dbAccessor.UpdateProduct(id, product) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("all/product-types")]
        public IActionResult GetAllProductTypes()
        {
            return Ok(dbAccessor.GetAllProductTypes());
        }
    }
}