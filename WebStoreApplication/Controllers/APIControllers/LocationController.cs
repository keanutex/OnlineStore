using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;

namespace WebStoreApplication.Controllers.APIControllers
{
    [Route("location/")]
    [ApiController]
    public class LocationController : Controller
    {
        private readonly IAccessDBContext dbAccessor;

        public LocationController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }
        [HttpGet("{userId}")]
        public IActionResult GetLocation(int userId)
        {
            return Ok(dbAccessor.GetLocation(userId));
        }

        [HttpGet("city")]
        public IActionResult GetAllCities()
        {
            return Ok(dbAccessor.GetAllCities());
        }
    }
}