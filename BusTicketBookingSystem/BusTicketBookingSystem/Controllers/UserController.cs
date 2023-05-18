using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate([FromBody] User model)
        {
            var token = await _userService.Authenticate(model.UserName, model.Password);
            if (token == null)
            {
                // Authentication failed
                return Unauthorized();
            }
            
            return Ok(new { Token = token });
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            try
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Password = model.Password
                };

                await _userService.Register(user);

                return Ok();
            }
            catch (Exception ex)
            {
                // Handle exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to create user.{ex}");
            }
        }

        [Authorize]
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, [FromBody] User model)
        {
            try
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Password = model.Password
                };

                await _userService.UpdateUser(userId, user);

                return Ok();
            }
            catch(Exception ex)
            {
                // Handle exception
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update user with ID: {userId}.");
            }
        }
    }
}
