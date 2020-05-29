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
        public IActionResult Login([FromForm] LoginModel login)
        {
            try
            {
                if (common.CreateHashPassword(login.password).Equals(dbAccessor.GetUserPassword(login.username), StringComparison.InvariantCultureIgnoreCase))
                {
                    UserModel user = dbAccessor.GetUser(login.username);
                    Session.userId = user.userId;
                    Session.username = login.username;
                    return Redirect("https://localhost:5001/");
                }
                else
                {
                    return Redirect("https://localhost:5001/Home/Login");
                }
            }
            catch(Exception ex)
            {
                return Redirect("https://localhost:5001/Home/Login");
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            Session.userId = 0;
            Session.username = null;
            return Redirect("https://localhost:5001/");
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterModel newUser)
        {
            try
            {
                UserModel user = dbAccessor.GetUser(newUser.username);

                if (user == null)
                {
                    newUser.password = common.CreateHashPassword(newUser.password);
                    if (dbAccessor.AddUser(newUser) == 1)
                    {
                        return Redirect("https://localhost:5001/Home/Login");
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
