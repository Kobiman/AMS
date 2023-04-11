﻿using AMS.Shared;
using AMS.Shared.Dto;
using IResult = AMS.Shared.IResult;

namespace AMS.Server.Services
{
    public interface IAgentService
    {
        Task<IResult> AddAgent(Agent agent);
        Task<IEnumerable<AgentReportDto>> GetAgentReport(DateRange period);
        Task<IEnumerable<AgentDto>> GetAgents();
    }
}
