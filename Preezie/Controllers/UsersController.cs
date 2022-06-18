using Microsoft.AspNetCore.Mvc;
using Preezie.Shared.DTOs.Users;

namespace Preezie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        public UsersController()
        {
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return null;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User_DTO user_DTO)
        {
            return null;
        }

        [HttpPut("{userID}")]
        public IActionResult UpdateUser([FromRoute] string userID)
        {
            return null;
        }
    }
}