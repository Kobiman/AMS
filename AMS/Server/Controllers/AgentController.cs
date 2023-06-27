using AMS.Server.Services;
using AMS.Shared;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        IAgentService _agentService;
        private readonly IMapper _mapper;

        public AgentController(IAgentService agentService, IMapper mapper)
        {
            _agentService = agentService;
            _mapper = mapper;
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
        [HttpGet("GetApprovedAgents")]
        public async Task<IActionResult> GetApprovedAgents()
        {
            var list = await _agentService.GetAgents();
            var result = list.Where(x => x.Approved);
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetAgentReports")]
        public async Task<IActionResult> GetAgentReport(DateRange period)
        {
            var result = await _agentService.GetAgentReport(period);
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("EditAgent")]
        public async Task<ActionResult<Result<AgentDto>>> EditAgent(AgentDto agentDto)
        {
            var agent = _mapper.Map<Agent>(agentDto);
            var result = await _agentService.EditAgent(agent);
            var resultDto = _mapper.Map<AgentDto>(result.Value);
            if (result != null)
                return Ok(resultDto);
            return BadRequest(resultDto);
        }

        [HttpDelete]
        public async Task<ActionResult<Result<bool>>> DeleteAgent(AgentDto agentDto)
        {
            var agent = _mapper.Map<Agent>(agentDto);
            var result = await _agentService.DeleteAgent(agent);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("approve")]
        public async Task<ActionResult<Result<bool>>> ApproveAgent(AgentDto agent)
        {
            var result = await _agentService.ApproveAgent(agent.AgentId);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
