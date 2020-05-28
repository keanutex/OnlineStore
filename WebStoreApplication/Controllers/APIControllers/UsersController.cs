﻿using System;
using Microsoft.AspNetCore.Mvc;
using WebStoreApplication.Models;
using WebStoreApplication.Shared;

namespace WebStoreApplication.Controllers
{
    [Route("user/")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IAccessDBContext dbAccessor;
        private readonly Common common = new Common();

        public UsersController(IAccessDBContext dbAccessor)
        {
            this.dbAccessor = dbAccessor;
        }

        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            try
            {
                UserModel user = dbAccessor.GetUser(username);

                if (user== null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(dbAccessor.GetUser(username));
                }
               
            }
            catch(Exception ex)
            {
                return NotFound(ex);
            }
            
        }

        [HttpPut("")]
        public IActionResult UpdateUser(UserModel user)
        {
            user.password = common.CreateHashPassword(user.password);
            if (dbAccessor.UpdateUser(user) == 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("address")]
        public IActionResult UpdateAddress(AddressModel address)
        {
           
            if (dbAccessor.UpdateAddress( address) == 1)
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