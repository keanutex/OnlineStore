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
        [HttpGet("{username}")]
        public IActionResult GetLocation(string username)
        {
            return Ok(dbAccessor.GetLocation(username));
        }

        [HttpGet("city")]
        public IActionResult GetAllCities()
        {
            return Ok(dbAccessor.GetAllCities());
        }

        [HttpGet("address/{addressId}")]
        public IActionResult GetAddress(int addressId)
        {
            return Ok(dbAccessor.GetAddress(addressId));
        }

    }
}