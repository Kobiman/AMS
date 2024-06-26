﻿using AMS.Server.Services;
using AMS.Shared;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        [HttpGet("GetAgent/{id}")]
        public async Task<ActionResult<Agent>> GetAgent(string id)
        {
            var result = await _agentService.GetAgent(id);
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetApprovedAgents")]
        public async Task<IActionResult> GetApprovedAgents()
        {
            //var list = await _agentService.GetAgents();
            var list = await _agentService.GetAgentsList();
            var result = list.Where(x => x.Approved);
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetAgentReports")]
        public async Task<IActionResult> GetAgentReport(DateRange period)
        {
            //var access_token = await HttpContext.GetTokenAsync("access_token");
            //var handler = new JwtSecurityTokenHandler();
            //var token = handler.ReadJwtToken(access_token);
            //var role = GetRole(token);
            //var locationId = GetLocationId(token);
            var result = await _agentService.GetAgentReport(period);
            if (result is not null) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("GetAgentReports/{agentId}")]
        public async Task<IActionResult> GetAgentReport([FromRoute]string agentId, [FromBody]DateRange period)
        {
            var result = await _agentService.GetAgentReport(period);
            if (result is not null) return Ok(result.FirstOrDefault(x=>x.AgentId == agentId));
            return BadRequest(result);
        }

        [HttpPut("EditAgent")]
        public async Task<ActionResult<Result<Agent>>> EditAgent(AgentDto agentDto)
        {
            //var agent = _mapper.Map<Agent>(agentDto);
            Agent agent = new Agent()
            {
                AgentId = agentDto.AgentId,
                Name = agentDto.Name,
                Email = agentDto.Email,
                Phone = agentDto.Phone,
                HouseNo = agentDto.HouseNo,
                Region = agentDto.Region
            };
            var result = await _agentService.EditAgent(agent);
     
            if (result != null)
                return Ok(result);
            return BadRequest(result);
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
        [HttpGet("GetAgentGameCommissions/{id}")]
        public async Task<ActionResult<IEnumerable<AgentGameCommissionDto>>> GetAgentGameCommissions(string id)
        {
            var result = await _agentService.GetAgentGameCommissions(id);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost("AddCommission")]
        public async Task<ActionResult<Result>> AddCommission(AgentGameCommissionDto commission)
        {
            var result = await _agentService.AddCommission(commission);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("EditCommission")]
        public async Task<ActionResult<Result>> EditCommission(AgentGameCommissionDto commission)
        {
            var result = await _agentService.EditCommission(commission);
            if (result != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("GetSalesCommission/{agentId}/{gameId}")]
        public async Task<ActionResult<decimal?>> GetSalesCommission(string agentId, string gameId)
        {
            var result = await _agentService.GetSalesCommission(agentId,gameId);
            return Ok(result);            
        }

        static string? GetLocationId(JwtSecurityToken token)
        {
            return token?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Locality)?.Value;
        }

        static string? GetRole(JwtSecurityToken token)
        {
            return token?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        }
    }
}
