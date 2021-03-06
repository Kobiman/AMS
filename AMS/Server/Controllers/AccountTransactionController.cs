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
        public async Task<ActionResult<AccountTransactionDto>> GetAdministrativeTransaction(string Id)
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
        public async Task<ActionResult<SalesDto>> AddAdministrativeTransaction([FromBody] AccountTransaction adminTransaction)
        {
            try
            {
                if (adminTransaction == null)
                    return BadRequest();
                var result = await accTransactionService.AddAdministrativeTransaction(adminTransaction);

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
        [HttpPost("AddAccountTransaction")]
        public async Task<ActionResult> AddAccountTransaction([FromBody] AddTransactionDto  transactionDto)
        {
            var result = await accTransactionService.AddAccountTransaction(transactionDto);
            if (result.IsSucessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Transfer")]
        public async Task<ActionResult<AccountTransactionDto>> AddAdministrativeTransaction([FromBody] TransferDto transferDto)
        {
            try
            {
                if (transferDto == null)
                    return BadRequest();
                var result = await accTransactionService.Transfer(transferDto);

                return CreatedAtAction(nameof(GetAdministrativeTransaction), new { id = result.Id }, result);
                //if (result.IsSucessful) 
                //    return Ok(result);
                //return BadRequest(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }

        }

        [HttpGet("TransferReport/{period}")]
        public async Task<IActionResult> TransferReport(string period)//should be by period
        {
             return Ok(await accTransactionService.TransferReport(period));
        }

        [HttpPut()]
        public async Task<ActionResult<AccountTransactionDto>> EditTransaction(AccountTransaction adminTransaction)
        {
            try
            {
                var TransactionToEdit = await accTransactionService.GetTransaction(adminTransaction.Id);
                if (TransactionToEdit == null)
                    return NotFound();
                return await accTransactionService.UpdateAdministrativeTrasaction(adminTransaction);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult<AccountTransactionDto>> DeleteTransaction(string Id)
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

        //PAY OUT
        [HttpPost("Payout")]
        public async Task<ActionResult<AccountTransactionDto>> AddPayout([FromBody] AddPayoutDto addPayoutDto)
        {
            try
            {
                if (addPayoutDto == null)
                    return BadRequest();
                var result = await accTransactionService.Payout(addPayoutDto);

                return CreatedAtAction(nameof(GetAdministrativeTransaction), new { id = result.Id }, result);
                //if (result.IsSucessful) 
                //    return Ok(result);
                //return BadRequest(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }

        }
        //PayoutReport
        [HttpGet("PayoutReport/{period}")]
        public async Task<IActionResult> PayoutReport(string period)//should be by period
        {
            return Ok(await accTransactionService.PayoutReport(period));
        }
    }
}
