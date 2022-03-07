using AMS.Server.Services;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdministrativeTransactionController : ControllerBase
    {
        private readonly IAdministrativeTransactionService accTransactionService;
        public AdministrativeTransactionController(IAdministrativeTransactionService _accTransationService)
        {
            accTransactionService = _accTransationService;
        }

        [HttpGet("GetTransactions/{period}")]
        public async Task<IActionResult> GetAdministrativeTransactions(string? period="Today")
        {
            try
            {
                return Ok(await accTransactionService.GetAdmininistrativeTransactions(period));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data");
            }
        }


        [HttpGet("Id")]
        public async Task<ActionResult<AdministrativeTransactionDto>> GetAdministrativeTransaction(string Id)
        {
            try
            {
                var result = await accTransactionService.GetAdministrativeTransactionById(Id);
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
        public async Task<ActionResult<AccountTransactionDto>> AddAdministrativeTransaction([FromBody] AccountTransaction accountTransaction)
        {
            try
            {
                if (accountTransaction == null)
                    return BadRequest();
                var result = await accTransactionService.AddAdministrativeTransaction(accountTransaction);

                return CreatedAtAction(nameof(GetAdministrativeTransaction),new { id = result.Id },result);
                //if (result.IsSucessful) 
                //    return Ok(result);
                //return BadRequest(result);
            }
            catch (Exception)
            {
               return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
            
        }

        [HttpPut()]
        public async Task<ActionResult<AdministrativeTransactionDto>> EditTransaction(AccountTransaction accountTransaction)
        {
            try
            {
                var TransactionToEdit = await accTransactionService.GetTransaction(accountTransaction.Id);
                if (TransactionToEdit == null)
                    return NotFound();
                return await accTransactionService.UpdateAdministrativeTrasaction(accountTransaction);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<AdministrativeTransactionDto>> DeleteTransaction(string Id)
        {
            try
            {
                var TransactionToDelete = await accTransactionService.GetTransaction(Id);
                if (TransactionToDelete == null)
                    return NotFound();
                return await accTransactionService.DeleteAdministrativeTransaction(Id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Transaction");
            }
        }
    }
}
