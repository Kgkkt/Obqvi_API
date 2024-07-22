using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obqvi_API.DB;
using Obqvi_API.Extensions;
using Obqvi_API.ViewModels.ResponseModels;
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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserVM user)
        {
            var pass = user.Password.Encrypt();
            var u = await _db.Users.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == pass);
            var r = new BaseResponseVM();
            if(u == null)
            {
                r.HasError = true;               
            }
            else
            {
                r.Data = u;
            }
            return Ok(r);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserVM user)
        {
            var hasOld =await _db.Users.FirstOrDefaultAsync(x => x.Username == user.UserName);
            if(hasOld != null)
            {
                return BadRequest();
            }
           
            _db.Users.Add(new DB.Models.User 
            { 
                Username = user.UserName,
                Password = user.Password!.Encrypt(),
                Mail = user.Email
            });

            await _db.SaveChangesAsync();

            return Ok(user);
        }
    }
}
