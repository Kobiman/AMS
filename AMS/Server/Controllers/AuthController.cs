using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AMS.Shared.Dto;

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
                var response = await _authService.Register(new User { Email = user.Email,Role=user.Role,StaffId=user.StaffId }, user.Password);
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

        [HttpPost("ChangePassword"),Authorize]
        public async Task<ActionResult<Result<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _authService.ChangePassword(int.Parse(userId), newPassword);
            if (response.IsSucessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
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
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _authService.GetUsers();
                       
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<Result<int>>> DeleteUser(int Id)
        {
            var response = await _authService.DeleteUser(Id);
            if(response.IsSucessful)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<Result<UserDto>>> EditUser(UserDto user)
        {
            try
            {
                return await _authService.EditUserRole(user.Id, user.Role);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating User");
            }
        }

    }
}
