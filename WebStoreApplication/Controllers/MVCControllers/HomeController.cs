using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStoreApplication.Models;
using WebStoreApplication.Shared;

namespace WebStoreApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        public IActionResult Logout()
        {
            return View();
        }

        public IActionResult ViewProfile()
        {
            return View();
        }

        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Admin()
        {
            if(Session.username != "Keanu")
                return View("Products");
            return View();
        }

        public IActionResult Cart()
        {
            if (Session.username == null) {
                return View("Login");
            }
            return View();
        }

        public IActionResult AddProduct()
        {
            if (Session.username == null)
            {
                return View("Login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
