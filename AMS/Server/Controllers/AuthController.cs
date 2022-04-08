using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Result<int>>> Register([FromBody] UserRegister user)
        {
            try
            {
                var response = await _authService.Register(new User { Email = user.Email }, user.Password);
                if (response.IsSucessful)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Registering User");
            }

        }
        [HttpPost("Login")]
        public async Task<ActionResult<Result<string>>> Login(UserLogin user)
        {
            var response = await _authService.Login(user.Email, user.Password);
            if(response.IsSucessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
