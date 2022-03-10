using AMS.Server.Services;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtorsController : ControllerBase
    {
        IDebtorsService _debtService;
        public DebtorsController(IDebtorsService debtService)
        {
            _debtService = debtService;
        }
        [HttpPost]
        public async Task<ActionResult> AddDebtor([FromBody]Debtors debtors)
        {
            var result = await _debtService.AddDebtor(debtors);
            try
            {
                if (result == null)
                { 
                    return BadRequest(result);
                }else
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Debtor");
            }
            
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var result = await _debtService.GetDebtors();
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }
    }
}
