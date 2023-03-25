using AMS.Client.Pages;
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
                AmountPaid = x.Transactions.Sum(x => x.WinAmount),
                OutstandingBalance = x.Transactions.Sum(x => x.DailySales) - x.Transactions.Sum(x => x.WinAmount)
            });
        }

        public async Task<IEnumerable<AgentReportDto>> GetAgentReport(string period)
        {
            DateRange.GetDates(period, out DateTime sDate, out DateTime eDate);
            DateTime startDate = sDate;
            DateTime endDate = eDate;
            //string startDate = $"{sDate.Year}-{sDate.Month}-{sDate.Day}";
            //string endDate = $"{eDate.Year}-{eDate.Month}-{eDate.Day}";
            //var query = $"SELECT * FROM [dbo].[View_AgentReport] where [CreatedDate] between '{startDate}' and '{endDate}'";
            //var results = await query.Execute();
            //return results[0].ToList<AgentReportDto>();

            var sales = await _context.Sales.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToListAsync();
            var payout_payin = await _context.Payouts.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToListAsync();
            var agents = await _context.Agents.Select(x => new { x.Name, x.AgentId }).ToDictionaryAsync(x=>x.AgentId,x=>x.Name);
            var games = await _context.Games.Select(x => new { x.Name, x.Id }).ToDictionaryAsync(x => x.Id, x => x.Name);
            return sales.Select(x => {
                var payinAmount = payout_payin.Where(y => y.EntryDate == x.EntryDate && y.AgentId == x.AgentId).Sum(y => y.PayinAmount);
                var payoutAmount = payout_payin.Where(y => y.EntryDate == x.EntryDate && y.AgentId == x.AgentId).Sum(y => y.PayoutAmount);
                return new AgentReportDto
                {
                    EntryDate = x.EntryDate,
                    DrawDate = x.DrawDate,
                    AgentId = x.AgentId,
                    Name = agents.TryGetValue(x.AgentId,out string? agent)? agent : "",
                    Sales = x.DailySales,
                    Game = games.TryGetValue(x.GameId, out string? game) ? game : "",
                    Wins = x.WinAmount,
                    Payin = payinAmount,
                    Payout = payoutAmount,
                    Balance = x.DailySales - payinAmount - payoutAmount
                };
            });
        }
    }
}
