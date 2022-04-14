using AMS.Server.Services;
using AMS.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody]Account account)
        {
            var result = await _accountService.AddAccount(account);
            if(result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAccounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var result = await _accountService.GetAccounts();
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetIncomeStatement")]
        public async Task<IActionResult> GetIncomeStatement([FromQuery]int year)
        {
            var result = await _accountService.GetIncomeStatement(year);
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetBalanceSheet")]
        public async Task<IActionResult> GetBalanceSheet([FromQuery] int year)
        {
            var result = await _accountService.GetBalanceSheet(year);
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }
    }
}
