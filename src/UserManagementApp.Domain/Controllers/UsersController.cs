using Microsoft.AspNetCore.Mvc;
using UserManagementApp.Application.Interfaces;
using UserManagementApp.Application.Services;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User user)
        {
            var userId = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = userId }, null);
        }
    }
}
