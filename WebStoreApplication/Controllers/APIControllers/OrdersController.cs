using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;
using WebStoreApplication.Shared;
using System.Collections.Generic;

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

        [HttpGet("all/")]
        public IActionResult GetAllOrderedItems()
        {
            int userID = Session.userId;
            string statusDescription = "Accepted";
            return Ok(dbAccessor.GetAllProductsInOrder(userID, statusDescription));
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