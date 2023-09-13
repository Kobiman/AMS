using AMS.Client.Pages;
using AMS.Server.Extensions;
using AMS.Server.Migrations;
using AMS.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AMS.Server.Services
{
    public class AgentService : IAgentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthService _authService;

        public AgentService(ApplicationDbContext context,
            IAuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        public async Task<Shared.IResult> AddAgent(Agent agent)
        {
            agent.StaffId = _authService.GetStaffID();
            agent.LocationId = _authService.GetLocationID() == ""? 0: Convert.ToInt16(_authService.GetLocationID());
            var originalAccount = _context.Agents.FirstOrDefault(x => x.Name == agent.Name);
            if (originalAccount != null) return new Result(false, $"Agent with name {agent.Name} already exist.");
            _context.Agents.Add(agent);
            var result = await _context.SaveChangesAsync();
            if (result > 0) return new Result(true, "Agent saved successfully.");
            return new Result(false, "Operation failled.");
        }

        public async Task<IEnumerable<AgentDto>> GetAgents()
        {
            var results =  await _context.Agents.Include(x=> x.Transactions).Where(x=>x.Approved).ToListAsync();
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
            var agents = await _context.Agents.Select(x => new { x.Name, x.AgentId }).ToDictionaryAsync(x => x.AgentId, x => x.Name);
            var bfAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountName == "BALANCE B/F");

            var sales = await _context.Sales.Where(x => x.Approved && x.EntryDate >= startDate.Date && x.EntryDate <= endDate.Date && x.AccountId != bfAccount.AccountId).OrderBy(x=>x.EntryDate).Select(x => new
            {
                x.AccountId,
                x.AgentId,
                x.DailySales,
                x.Description,
                x.EntryDate,
                x.DrawDate,
                x.WinAmount,
                x.GameId,
                x.ReceiptNumber,
                x.Id
            })
            .Select(x => new SalesDto2
            (
                x.AccountId,
                x.AgentId,
                x.DailySales,
                x.Description,
                x.EntryDate,
                x.DrawDate,
                x.WinAmount,
                x.GameId,
                x.ReceiptNumber,
                x.Id
            ))
            .ToListAsync();

            var payout_payin = await _context.Payouts.OrderBy(x => x.EntryDate).Where(x => x.Approved && x.EntryDate >= startDate.Date && x.EntryDate <= endDate.Date).Select(x => new
            {
                x.AgentId,
                x.GameId,
                x.PayinAmount,
                x.PayoutAmount,
                x.Amount,
                x.Type,
                x.SalesId,
                x.EntryDate
            })
            .Select(x => new PayinPayout
            (
                x.AgentId,
                x.GameId,
                x.PayinAmount,
                x.PayoutAmount,
                x.Amount,
                x.Type,
                x.SalesId,
                x.EntryDate
            )).ToListAsync();

            return sales.GetAgentReport(agents, payout_payin);
        }

        public async Task<Result<Agent>> EditAgent(Agent agent)
        {
            agent.StaffId = _authService.GetStaffID();
            agent.LocationId = Convert.ToInt16(_authService.GetLocationID());
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
            agent.Approved = true;
            agent.ApprovedBy = _authService.GetStaffID();
            if(await _context.SaveChangesAsync() > 0) {
                return new Result<bool>(true, true, "Record Approved!");
            }
            return new Result<bool>(false, false, "Operation Failed!");
        }

    }
}
