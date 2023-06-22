﻿using AMS.Client.Pages;
using AMS.Server.Migrations;
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
                Approved = x.Approved,
                Sales = x.Transactions.Sum(x => x.DailySales),
                AmountPaid = x.Transactions.Sum(x => x.WinAmount),
                OutstandingBalance = x.Transactions.Sum(x => x.DailySales) - x.Transactions.Sum(x => x.WinAmount)
            }).OrderBy(x=>x.Name);
        }

        public async Task<IEnumerable<AgentReportDto>> GetAgentReport(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);

            var sales = await _context.Sales
                .GroupBy(x => x.AgentId)
                .Select(x => new
                {
                    AgentId = x.Key,
                    DailySales = x.Sum(x => x.DailySales),
                    WinAmount = x.Sum(x => x.WinAmount),
                })
                .Select(x => new
                {
                    x.AgentId,
                    x.WinAmount,
                    x.DailySales
                }).ToListAsync();
            var payout_payin = await _context.Payouts.Select(x=>new
            {
                x.AgentId,
                x.GameId,
                x.PayinAmount,
                x.PayoutAmount,
                x.Amount
            }).ToListAsync();
            var agents = await _context.Agents.Select(x => new { x.Name, x.AgentId }).ToDictionaryAsync(x => x.AgentId, x => x.Name);
            //var games = await _context.Games.Select(x => new { x.Name, x.Id }).ToDictionaryAsync(x => x.Id, x => x.Name);
            return sales.Select(x =>
            {
                var payinAmount = payout_payin
                .Where(y => y.AgentId == x.AgentId)
                .Sum(y => y.PayinAmount);
                var payoutAmount = payout_payin
                .Where(y => y.AgentId == x.AgentId)
                .Sum(y => y.PayoutAmount);
                var amount = payout_payin
                .Where(y => y.AgentId == x.AgentId)
                .Sum(y => y.Amount);
                return new AgentReportDto
                {
                    //EntryDate = x.EntryDate,
                    //DrawDate = x.DrawDate,
                    AgentId = x.AgentId,
                    Name = agents.TryGetValue(x.AgentId, out string? agent) ? agent : "",
                    Sales = x.DailySales,
                    //Game = games.TryGetValue(x.GameId, out string? game) ? game : "",
                    Wins = x.WinAmount,
                    Payin = payinAmount,
                    Payout = payoutAmount,
                    Balance = x.DailySales - x.WinAmount - amount
                };
            });
        }

        public async Task<Result<Agent>> EditAgent(Agent agent)
        {
            _context.Agents.UpdateRange(agent);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return new Result<Agent>(true, agent, "Record Updated");
            return new Result<Agent>(false, new Agent(), "Operation Failed");
        }

        public async Task<Result<bool>> DeleteAgent(Agent agent)
        {
            _context.Agents.Remove(agent);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return new Result<bool>(true, true, "Record Deleted");
            return new Result<bool>(false, false, "Operation Failed");
        }

        public async Task<Result<bool>> ApproveAgent(string id)
        {
            var agent = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == id);
            agent.Approved= true;
            if(await _context.SaveChangesAsync() > 0) {
                return new Result<bool>(true, true, "Record Approved!");
            }
            return new Result<bool>(false, false, "Operation Failed!");
        }

    }
}
