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

        public async Task<IEnumerable<AgentReportDto>> GetAgentReport(string period)
        {
            DateRange.GetDates(period, out DateTime sDate, out DateTime eDate);
            string startDate = $"{sDate.Year}-{sDate.Month}-{sDate.Day}";
            string endDate = $"{eDate.Year}-{eDate.Month}-{eDate.Day}";
            var query = $"SELECT * FROM [dbo].[View_AgentReport] where [CreatedDate] between '{startDate}' and '{endDate}'";
            var results = await query.Execute();
            return results[0].ToList<AgentReportDto>();
            //return results.Select(x => new AgentReportDto
            //{
            //    AgentId = x.AgentId,
            //    Name = x.Name,
            //    Sales = x.Transactions.Sum(x => x.DailySales),
            //    PayInAmount = x.Transactions.Sum(x => x.PayInAmount),
            //    //PayOut = x.Payouts.Sum(x => x.Amount),
            //    OutstandingBalance = x.Transactions.Sum(x => x.DailySales) - x.Transactions.Sum(x => x.PayInAmount)
            //});
        }
    }
}
