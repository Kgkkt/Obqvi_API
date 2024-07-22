using Microsoft.AspNetCore.Http;
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

        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> CreateNewUser([FromBody] CreateNewUserVM user)
        {
            _db.Users.Add(new DB.Models.User 
            { 
                Username = user.UserName,
                Password = user.Password,
                Mail = user.Email
            });

            await _db.SaveChangesAsync();

            return Ok(user);
        }
    }
}
