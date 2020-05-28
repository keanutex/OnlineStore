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
        [HttpGet("{id}")]
        public IActionResult GetLocation(int id)
        {
            return Ok(dbAccessor.GetLocation(id));
        }
    }
}