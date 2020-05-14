using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStoreApplication.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Adds user to the DB
        /// </summary>
        /// <param name="id"></param>        
        [HttpPost("Users/AddUser/{id}")]
        public IActionResult AddUser(long id)
        {
            // code code code
            Console.Write(id);
            return NoContent();
        }


        /// <summary>
        /// Returns all the users in the DB
        /// </summary>
        [HttpGet("Users/GetUsers")]
        public IActionResult GetUsers(long id)
        {
            // code code code
            Console.Write(id);
            return NoContent();
        }

    }
}