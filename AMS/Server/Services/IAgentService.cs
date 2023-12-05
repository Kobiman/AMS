using AMS.Shared;
using AMS.Shared.Dto;
using IResult = AMS.Shared.IResult;

namespace AMS.Server.Services
{
    public interface IAgentService
    {
        Task<IResult> AddAgent(Agent agent);
        Task<IEnumerable<AgentReportDto>> GetAgentReport(DateRange period);
        Task<IEnumerable<AgentDto>> GetAgents();
        Task<Agent> GetAgent(string id);

        Task<Result<Agent>> EditAgent(Agent agent);
        Task<Result<bool>> DeleteAgent(Agent agent);
        Task<Result<bool>> ApproveAgent(string id);

        Task<IEnumerable<AgentGameCommissionDto>> GetAgentGameCommissions(string id);
        Task<Result> AddCommission(AgentGameCommissionDto commission);
        Task<Result> EditCommission(AgentGameCommissionDto commission);
    }
}
