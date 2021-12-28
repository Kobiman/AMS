using AMS.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("AddAccount")]
        public IActionResult AddAccount(Account account)
        {

            return Ok(account);
        }
    }
}
