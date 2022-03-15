using AMS.Server.Services;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AgentsTransactionController : ControllerBase
    {
        private readonly IAgentsTransactionService accTransactionService;
        public AgentsTransactionController(IAgentsTransactionService _accTransationService)
        {
            accTransactionService = _accTransationService;
        }

        [HttpGet("GetTransactions/{period}")]
        public async Task<IActionResult> GetAgentsTransactions(string? period="Today")
        {
            try
            {
                return Ok(await accTransactionService.GetAgentsTransaction(period));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
        }

        [HttpGet("{inOut}/{period}")]
        public async Task<IActionResult> GetTransactionsCashInOut(string inOut, string? period)
        {
            try
            {
                return Ok(await accTransactionService.GetTransactionsCashInCashOut(inOut, period));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
        }
        [HttpGet("Id")]
        public async Task<ActionResult<AgentsTransactionDto>> GetAccountTransaction(string Id)
        {
            try
            {
                var result = await accTransactionService.GetTransactionById(Id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
        }

        [HttpPost("AddTransaction")]
        public async Task<ActionResult<AgentsTransactionDto>> AddAgentsTransaction([FromBody] AgentsTransaction accountTransaction)
        {
            try
            {
                if (accountTransaction == null)
                    return BadRequest();
                var result = await accTransactionService.AddAgentsTransaction(accountTransaction);

                return CreatedAtAction(nameof(GetAccountTransaction),new { id = result.Id },result);
                //if (result.IsSucessful) 
                //    return Ok(result);
                //return BadRequest(result);
            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
            
        }

        [HttpPut]
        public async Task<ActionResult<AgentsTransactionDto>> EditTransaction(AgentsTransaction accountTransaction)
        {
            try
            {
                var TransactionToEdit = await accTransactionService.GetTransaction(accountTransaction.Id);
                if (TransactionToEdit == null)
                    return NotFound();
                return await accTransactionService.UpdateAgentsTrasaction(accountTransaction);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<AgentsTransactionDto>> DeleteTransaction(string Id)
        {
            try
            {
                var TransactionToDelete = await accTransactionService.GetTransaction(Id);
                if (TransactionToDelete == null)
                    return NotFound();
                return await accTransactionService.DeleteAgentsTransaction(Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Transaction");
            }
        }
    }
}
