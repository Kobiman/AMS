using AMS.Server.Services;
using AMS.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }
        [HttpPost("AddAgent")]
        public async Task<IActionResult> AddAgent([FromBody] Agent agent)
        {
            var result = await _agentService.AddAgent(agent);
            if (result.IsSucessful) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAgents")]
        public async Task<IActionResult> GetAgents()
        {
            var result = await _agentService.GetAgents();
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAgentReport")]
        public async Task<IActionResult> GetAgentReport()
        {
            var result = await _agentService.GetAgentReport();
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }
    }
}
