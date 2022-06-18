using Microsoft.AspNetCore.Mvc;
using Preezie.Services.UsersService;
using Preezie.Shared.DTOs.Users;

namespace Preezie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;

        public UsersController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var usersList = await _usersService.GetUsers();

            return Ok(usersList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser_DTO userDTO)
        {
            await _usersService.CreateUser(userDTO);

            return Ok();
        }

        [HttpPut("{userID}")]
        public async Task<IActionResult> UpdateUser([FromRoute] string userID, [FromBody] UpdateUser_DTO userUpdateDTO)
        {
            await _usersService.UpdateUser(userID, userUpdateDTO);

            return Ok();
        }
    }
}