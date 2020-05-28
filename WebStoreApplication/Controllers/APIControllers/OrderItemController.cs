using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers.APIControllers
{
    [Route("orderitems/")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IAccessDBContext dbAccessor;

        public OrderItemController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }

        [HttpPost("")]
        public IActionResult AddOrderItems(OrderItemModel orderItem)
        {
            if (dbAccessor.AddOrderItems(orderItem) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{orderItemID}")]
        public IActionResult GetOrderItems(int orderItemID)
        {
            return Ok(dbAccessor.GetOrderItems(orderItemID));
        }

        [HttpGet("{orderID}")]
        public IActionResult GetAllOrderItems(int orderID)
        {
            return Ok(dbAccessor.GetAllOrderItems(orderID));
        }


        [HttpDelete("{orderItemID}")]
        public IActionResult RemoveOrderItems(int orderItemID)
        {
            if (dbAccessor.RemoveOrderItems(orderItemID) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{orderItemID}")]
        public IActionResult UpdateOrderItems(int orderItemID, OrderItemModel orderItem)
        {
            if (dbAccessor.UpdateOrderItems(orderItemID, orderItem) == 1)
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