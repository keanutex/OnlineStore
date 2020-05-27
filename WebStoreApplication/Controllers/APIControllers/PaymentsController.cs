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

        [HttpGet("")]
        public IActionResult GetToken()
        {
            payPalAccessor.getToken();
            return Ok();
        }

        [HttpGet("{total}")]
        public IActionResult CreatePayment(string total)
        {
            var url = payPalAccessor.createPayment(total);
            return Ok(new {approval_url = url.Result});
        }

        [HttpGet("execute/{payerid}/")]
        public IActionResult ExecutePayment(string payerid)
        {
            payPalAccessor.ExecutePayment(payerid);
            return Ok();
        }
    }
}