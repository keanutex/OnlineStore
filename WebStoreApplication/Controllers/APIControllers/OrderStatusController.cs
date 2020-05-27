using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers.APIControllers
{
    [Route("orderstatus/")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IAccessDBContext dbAccessor;

        public OrderStatusController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }

        [HttpPost("")]
        public IActionResult AddOrderStatus(OrderStatusModel orderStatus)
        {
            if (dbAccessor.AddOrderStatus(orderStatus) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{orderStatusID}")]
        public IActionResult GetOrderStatus(int orderStatusID)
        {
            return Ok(dbAccessor.GetOrderStatus(orderStatusID));
        }

        [HttpGet("orderstatus/")]
        public IActionResult GetAllOrdersStatuses()
        {
            return Ok(dbAccessor.GetAllOrdersStatuses());
        }


        [HttpDelete("{orderStatusID}")]
        public IActionResult RemoveOrderStatus(int orderStatusID)
        {
            if (dbAccessor.RemoveOrderStatus(orderStatusID) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{orderStatusID}")]
        public IActionResult UpdateOrderStatus(int orderStatusID, OrderStatusModel orderStatus)
        {
            if (dbAccessor.UpdateOrderStatus(orderStatusID, orderStatus) == 1)
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