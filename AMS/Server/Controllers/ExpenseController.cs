using AMS.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost("AddExpense")]
        public async Task<IActionResult> AddExpense([FromBody] AddExpenseDto expense)
        {
            var result = await _expenseService.AddExpenses(expense);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetExpenses")]
        public async Task<IActionResult> GetExpenses()
        {
            var result = await _expenseService.GetExpenses();
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

    }
}
