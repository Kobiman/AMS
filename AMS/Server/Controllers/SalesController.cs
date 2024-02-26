using AMS.Server.Services;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService accTransactionService;
        public SalesController(ISalesService _accTransationService)
        {
            accTransactionService = _accTransationService;
        }

        [HttpPost("GetTransactions")]
        public async Task<IActionResult> GetAgentsTransactions(DateRange period)
        {
            try
            {
                return Ok(await accTransactionService.GetAgentsTransaction(period));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
        }

        [HttpGet("GetOpenSalesWinsStortage")]
        public async Task<IActionResult> GetOpenSalesWinsStortage()
        {
            try
            {
                return Ok(await accTransactionService.GetOpenSalesWinsStortage());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
        }

        [HttpPost("{inOut}")]
        public async Task<IActionResult> GetTransactionsCashInOut([FromQuery]string inOut, DateRange period)
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
        public async Task<ActionResult<SalesDto>> GetAccountTransaction(string Id)
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
        public async Task<ActionResult<SalesDto>> AddSale([FromBody] SalesDto accountTransaction)
        {
            try
            {
                if (accountTransaction == null)
                    return BadRequest();
                var result = await accTransactionService.AddSales(accountTransaction);

                return CreatedAtAction(nameof(GetAccountTransaction),new { id = result.Id },result);
                //if (result.IsSucessful) 
                //    return Ok(result);
                //return BadRequest(result);
            }
            catch (Exception ex)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
            
        }

        [HttpPost("EditTransaction")]
        public async Task<ActionResult<SalesDto>> EditTransaction(Wins wins)
        {
            try
            {
                var TransactionToEdit = await accTransactionService.GetTransaction(wins.SalesId);
                if (TransactionToEdit == null)
                    return NotFound();
                return await accTransactionService.UpdateAgentsTrasaction(wins);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
        }

        [HttpPost("ApproveTransaction")]
        public async Task<ActionResult<SalesDto>> ApproveTransaction(Sales accountTransaction)
        {
            try
            {
                return await accTransactionService.ApproveSales(accountTransaction.SalesId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<SalesDto>> DeleteTransaction(string Id)
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
