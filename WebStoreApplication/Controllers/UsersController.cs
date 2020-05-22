using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers
{
    [Route("user/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IAccessDBContext dbAccessor;

        public UsersController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                return Ok(dbAccessor.GetUser(id));
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id , UserModel user)
        {
            if (dbAccessor.UpdateUser(id , user) == 1)
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