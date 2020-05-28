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

        [HttpGet("create-payment")]
        public IActionResult CreatePayment(string total)
        {
            var url = payPalAccessor.CreatePayment(total);
            if (url != null)
            {
                return Redirect(url.Result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("execute/")]
        public IActionResult ExecutePayment(string PayerID)
        {
            var result = payPalAccessor.ExecutePayment(PayerID);
            if (result != null)
            {
                return Redirect("https://localhost:5001/");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}