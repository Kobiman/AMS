using AMS.Server.Services;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountTransactionController : ControllerBase
    {
        private readonly IAccountTransactionService accTransactionService;
        public AccountTransactionController(IAccountTransactionService _accTransationService)
        {
            accTransactionService = _accTransationService;
        }

        [HttpGet("GetTransactions")]
        public async Task<IActionResult> GetAccountTransactions()
        {
            try
            {
                return Ok(await accTransactionService.GetAccountTransactions());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
        }

        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddAccountTransaction([FromBody] AccountTransaction accountTransaction)
        {
            try
            {
                var result = await accTransactionService.AddAccountTransaction(accountTransaction);
                if (result.IsSucessful) 
                    return Ok(result);
                return BadRequest(result);
            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
            
        }
    }
}
