using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditService _auditService;

        public AuditController(IAuditService auditService)
        {
            _auditService = auditService;
        }


        [Route("GetAuditLog")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Audit>>> GetAuditLog(DateRange period)
        {
            var result  = await _auditService.GetAuditRecords(period);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }


    }
}
