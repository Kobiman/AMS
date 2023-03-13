using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class AgentService : IAgentService
    {
        private readonly ApplicationDbContext _context;
        public AgentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shared.IResult> AddAgent(Agent agent)
        {
            var originalAccount = _context.Agents.FirstOrDefault(x => x.Name == agent.Name);
            if (originalAccount != null) return new Result(false, $"Agent with name {agent.Name} already exist.");
            _context.Agents.Add(agent);
            var result = await _context.SaveChangesAsync();
            if (result > 0) return new Result(true, "Agent saved successfully.");
            return new Result(false, "Operation failled.");
        }

        public async Task<IEnumerable<AgentDto>> GetAgents()
        {
            var results =  await _context.Agents.Include(x=> x.Transactions).ToListAsync();
            return results.Select(x => new AgentDto
            {
                AgentId = x.AgentId,
                Name = x.Name,
                Contact = x.Contact,
                CreatedDate = x.CreatedDate,
                Region = x.Region,
                Sales = x.Transactions.Sum(x => x.DailySales),
                AmountPaid = x.Transactions.Sum(x => x.PayInAmount),
                OutstandingBalance = x.Transactions.Sum(x => x.DailySales) - x.Transactions.Sum(x => x.PayInAmount)
            });
        }

        public async Task<IEnumerable<AgentReportDto>> GetAgentReport()
        {
            var results = await _context.Agents.Include(x => x.Transactions).ToListAsync();
            return results.Select(x => new AgentReportDto
            {
                AgentId = x.AgentId,
                Name = x.Name,
                Sales = x.Transactions.Sum(x => x.DailySales),
                PayInAmount = x.Transactions.Sum(x => x.PayInAmount),
                OutstandingBalance = x.Transactions.Sum(x => x.DailySales) - x.Transactions.Sum(x => x.PayInAmount)
            });
        }
    }
}
