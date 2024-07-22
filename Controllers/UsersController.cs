﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Obqvi_API.DB;
using Obqvi_API.ViewModels.Users;

namespace Obqvi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ObqviContext _db;

        public UsersController(ObqviContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Login([FromBody] LoginUserVM user)
        {
            if (user == null)
            {
                return BadRequest();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserVM user)
        {
            _db.Users.Add(new DB.Models.User 
            { 
                Username = user.UserName,
                Password = user.Password,
                Mail = user.Email
            });
            //test src

            await _db.SaveChangesAsync();

            return Ok(user);
        }
    }
}
