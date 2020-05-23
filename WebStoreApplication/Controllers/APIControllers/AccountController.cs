using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    [Route("user/")]
    [ApiController]
    public class AccountController : Controller
    {
        private UserManager<UserModel> UserMgr { get; }
        private SignInManager<UserModel> SignInMgr { get; }
        public AccountController(UserManager<UserModel>userManager,SignInManager<UserModel>signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var result = await SignInMgr.PasswordSignInAsync(login.Username, login.Password, false, false);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is "+result.ToString();
                return BadRequest(result);
            }
           


        }

        [HttpPost("register/{password}")]
        public async Task<IActionResult> Register(UserModel newUser , string password)
        {
           
            try
            {
                ViewBag.Message = "User already registered";
                UserModel user = await UserMgr.FindByNameAsync(newUser.UserName);
               
                if (user == null)
                {
                    IdentityResult result = await UserMgr.CreateAsync(newUser, password);
                    ViewBag.Message = "User was created";
                    if (result.Succeeded == false)
                    {
                        return BadRequest(result);
                    }
                    else
                    {
                        return Ok();
                    }
                    

                }
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex;
                return BadRequest(ex);
            }
            return View();
        }
    }
}