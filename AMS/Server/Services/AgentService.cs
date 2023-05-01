using AMS.Client.Pages;
using AMS.Shared;
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
                Phone = x.Phone,
                CreatedDate = x.CreatedDate,
                Email = x.Email,
                HouseNo = x.HouseNo,
                Region = x.Region,
                Sales = x.Transactions.Sum(x => x.DailySales),
                AmountPaid = x.Transactions.Sum(x => x.WinAmount),
                OutstandingBalance = x.Transactions.Sum(x => x.DailySales) - x.Transactions.Sum(x => x.WinAmount)
            }).OrderBy(x=>x.Name);
        }

        public async Task<IEnumerable<AgentReportDto>> GetAgentReport(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var sales = await _context.Sales.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToListAsync();
            var payout_payin = await _context.Payouts.Where(x => x.EntryDate >= startDate && x.EntryDate <= endDate).ToListAsync();
            var agents = await _context.Agents.Select(x => new { x.Name, x.AgentId }).ToDictionaryAsync(x => x.AgentId, x => x.Name);
            var games = await _context.Games.Select(x => new { x.Name, x.Id }).ToDictionaryAsync(x => x.Id, x => x.Name);
            var group = sales.OrderBy(x=>x.EntryDate).GroupBy(x=>x.AgentId);
            var agentReport = new List<AgentReportDto>();
            
            foreach (var g in group)
            {
                var cumlativeBalance = new List<decimal>();
                foreach (var y in g)
                {
                    var payinAmount = payout_payin
                   .Where(z => z.EntryDate == y.EntryDate && z.AgentId == y.AgentId && z.GameId == y.GameId)
                   .Sum(z => z.PayinAmount);
                    var payoutAmount = payout_payin
                    .Where(z => z.EntryDate == y.EntryDate && z.AgentId == y.AgentId && z.GameId == y.GameId)
                    .Sum(z => z.PayoutAmount);
                    var amount = payout_payin
                            .Where(z => z.EntryDate == y.EntryDate && z.AgentId == y.AgentId && z.GameId == y.GameId)
                            .Sum(y => y.Amount);
                    cumlativeBalance.Add(y.DailySales - y.WinAmount - amount);
                    agentReport.Add(new AgentReportDto
                    {
                        EntryDate = y.EntryDate,
                        DrawDate = y.DrawDate,
                        AgentId = y.AgentId,
                        Name = agents.TryGetValue(y.AgentId, out string? agent) ? agent : "",
                        Sales = y.DailySales,
                        Game = games.TryGetValue(y.GameId, out string? game) ? game : "",
                        Wins = y.WinAmount,
                        Balance = y.DailySales - y.WinAmount - amount,
                        Payin = payinAmount,
                        Payout = payoutAmount,
                        CumlativeBalance = cumlativeBalance.Sum()
                    });
                }
            }
            return agentReport;
        }
    }
}
