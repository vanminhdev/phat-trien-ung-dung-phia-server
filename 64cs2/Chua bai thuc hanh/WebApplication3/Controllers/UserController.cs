using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Dto.Users;
using WebApplication3.Services.Interfaces;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService,
            ILogger<UserController> logger) : base(logger)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateUserDto input)
        {
            try
            {
                _userService.Create(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto input)
        {
            try
            {
                string token = _userService.Login(input);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
    }
}
