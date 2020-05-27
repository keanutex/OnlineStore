using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers.APIControllers
{
    [Route("orders/")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IAccessDBContext dbAccessor;

        public OrdersController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }

        [HttpPost("")]
        public IActionResult AddOrder(OrdersModel order)
        {
            if (dbAccessor.AddOrder(order) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{orderID}")]
        public IActionResult GetOrder(int orderID)
        {
            return Ok(dbAccessor.GetOrder(orderID));
        }

        [HttpGet("{userID}")]
        public IActionResult GetAllOrdersForUser(int userID)
        {
            return Ok(dbAccessor.GetAllOrdersForUser(userID));
        }


        [HttpDelete("{orderID}")]
        public IActionResult RemoveOrder(int orderID)
        {
            if (dbAccessor.RemoveOrder(orderID) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{orderID}")]
        public IActionResult UpdateOrder(int orderID, OrdersModel order)
        {
            if (dbAccessor.UpdateOrder(orderID, order) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}