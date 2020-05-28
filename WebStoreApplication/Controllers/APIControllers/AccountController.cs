using System;
using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    [Route("user/")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccessDBContext dbAccessor;

        private readonly Common common;

        public AccountController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            
            if(common.CreateHashPassword(login.password).Equals(dbAccessor.GetUserPassword(login.username), StringComparison.InvariantCultureIgnoreCase))
            {
                return Ok();
            }
            else{
                return Unauthorized();
            }

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterModel newUser )
        {
          
            if (dbAccessor.GetUser(newUser.username).userId>0)
            {
                return BadRequest("Username already exists");
            }
            newUser.password = common.CreateHashPassword(newUser.password);
            if (dbAccessor.AddUser(newUser) == 1)
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