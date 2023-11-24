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

        [HttpPost("GetTransactions")]
        public async Task<IActionResult> GetAdministrativeTransactions(DateRange period)
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
        public async Task<ActionResult<AccountTransactionDto>> Transfer([FromBody] TransferDto transferDto)
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

        [HttpPost("TransferReport")]
        public async Task<IActionResult> TransferReport(DateRange period)//should be by period
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

                return Ok(result);
                //if (result.IsSucessful) 
                //    return Ok(result);
                //return BadRequest(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }

        }
        [HttpPost("AddAgentExpense")]
        public async Task<ActionResult<Result>> AddAgentExpense([FromBody] AddAgentExpenseDto addExpenseDto)
        {
            try
            {
                if (addExpenseDto == null)
                    return BadRequest();
                var result = await accTransactionService.AddAgentExpense(addExpenseDto);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }

        }
        [HttpPost("AgentExpensesReport")]
        public async Task<IActionResult> AgentExpenses(DateRange period)
        {
            try
            {
                return Ok(await accTransactionService.AgentExpenses(period));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }

        }
        [HttpPut("EditPayout")]
        public async Task<ActionResult<Result<AccountTransactionDto>>> EditPayout([FromBody] Payout editPayout)
        {
            try
            {
                if (editPayout == null)
                    return BadRequest();
                var result = await accTransactionService.EditPayout(editPayout);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
        }

        [HttpPut("ApprovePayout")]
        public async Task<ActionResult<Result<AccountTransactionDto>>> ApprovePayout([FromBody] Payout editPayout)
        {
            try
            {
                if (editPayout == null)
                    return BadRequest();
                var result = await accTransactionService.ApprovePayout(editPayout.Id);

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
        }

        //PayoutReport
        [HttpPost("PayoutReport")]
        public async Task<IActionResult> PayoutReport(DateRange period)
        {
            try
            {
                return Ok(await accTransactionService.PayoutReport(period));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }
            
        }

        [HttpPost("PayinReport")]
        public async Task<IActionResult> PayinReport(DateRange period)
        {
            try
            {
                return Ok(await accTransactionService.PayinReport(period));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Transaction");
            }

        }
    }
}
