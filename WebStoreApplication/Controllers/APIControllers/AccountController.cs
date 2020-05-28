using System;
using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;
using WebStoreApplication.Shared;

namespace WebStoreApplication.Controllers
{
    [Route("user/")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccessDBContext dbAccessor;

        private readonly Common common = new Common();
        

        public AccountController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }
      
        [HttpPost("login")]
        public ActionResult Login(LoginModel login)
        {
            try
            {
                if (common.CreateHashPassword(login.password).Equals(dbAccessor.GetUserPassword(login.username), StringComparison.InvariantCultureIgnoreCase))
                {
                    Session.username = login.username;
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        

        }

        [HttpPost("register")]
        public IActionResult Register(RegisterModel newUser )
        {

            try
            {
                UserModel user = dbAccessor.GetUser(newUser.username);

                if (user == null)
                {
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
                else
                {
                    return BadRequest("Username already exists");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
         
         
            

        }

        
    }
}