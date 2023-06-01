using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<PathRouteController> _logger;

        public UserController(IUserService userService, ILogger<PathRouteController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                    return NotFound();

                _logger.LogInformation("User Fetched by Id.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving an User.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Authenticate(UserDTO userdto)
        {
            try
            {
                var token = _userService.Authenticate(userdto.UserName, userdto.Password);
                if (token == null)
                {
                    // Authentication failed
                    return Unauthorized();
                }
                _logger.LogInformation("User Logged In & Token generated.");
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while Login an User.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to create user.{ex}");
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(NewUserDTO model)
        {
            try
            {
                var user = new NewUserDTO
                {
                    /*UserId = model.UserId,*/
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Password = model.Password,
                    IsAdmin = model.IsAdmin
                };

                _userService.Register(user);
                _logger.LogInformation("User successfully registered.");
                return Ok("User Successfully Registered");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering an User.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to create user.{ex}");
            }
        }


        /*[HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, UserPasswordDTO userdto)
        {
            try
            {
                var user = new User
                {
                    Password = userdto.Password
                };

                _userService.UpdateUser(userId, userdto);
                _logger.LogInformation("User updated.");
                return Ok("User Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an User.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to update user with ID: {userId}.");
            }
        }*/
    }
}
