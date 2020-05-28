using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    [Route("payments/")]
    [ApiController]
    public class PaymentsController: Controller
    {
        private readonly IAccessPayPalAPI payPalAccessor;

        public PaymentsController(IAccessPayPalAPI payPalAccessor)
        {
            this.payPalAccessor = payPalAccessor;
        }

        [HttpPost("")]
        public IActionResult GetToken()
        {
            var token = payPalAccessor.GetToken();
            if (token.Result != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("create-payment/{total}/")]
        public IActionResult CreatePayment(string total)
        {
            var url = payPalAccessor.CreatePayment(total);
            if (url != null)
            {
                return Ok(new {approval_url = url.Result});
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("execute/{payerid}/")]
        public IActionResult ExecutePayment(string payerid)
        {
            var result = payPalAccessor.ExecutePayment(payerid);
            if (result != null)
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