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
           var results = await _context.Agents.Include(x => x.Sales)
                                               .Include(x=>x.Wins)
                                               .ToListAsync();
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
                Commision = x.Commission,
                Sales = x.Sales.Sum(x => x.DailySales),
                AmountPaid = x.Wins.Sum(x => x.WinAmount),
                OutstandingBalance = x.Sales.Sum(x => x.DailySales) - x.Wins.Sum(x => x.WinAmount)
            }).OrderBy(x=>x.Name);
        }
        public async Task<Agent> GetAgent(string id)
        {
            var results = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == id);
            return results;
        }

        public async Task<IEnumerable<AgentReportDto>> GetAgentReport(DateRange period)
        {
            period.GetDates(out DateTime startDate, out DateTime endDate);
            var agents = await _context.Agents.Select(x => new { x.Name, x.AgentId }).ToDictionaryAsync(x => x.AgentId, x => x.Name);

            List<SalesDto2> _sales = await (from t in _context.Sales
                                                 //join w in _context.Wins on t.SalesId equals w.SalesId
                                                 select new SalesDto2
                                                 (
                                                     t.AccountId,
                                                     t.AgentId,
                                                     t.DailySales,
                                                     t.Description,
                                                     t.EntryDate,
                                                     t.DrawDate,
                                                     0,
                                                     t.GameId,
                                                     t.ReceiptNumber,
                                                     t.SalesId
                                                 )).ToListAsync();

            List<WinsDto> wins = await (from w in _context.Wins select new WinsDto(w.WinAmount, w.SalesId)).ToListAsync();

            var sales = Join(_sales, wins).ToList();

            var payout_payin = await _context.Payouts.OrderBy(x => x.EntryDate).Select(x => new
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

            var expenses = await _context.AgentExpenses.ToListAsync();

            return sales.GetAgentReport(agents, payout_payin, expenses);//.Where(x => x.EntryDate >= startDate.Date && x.EntryDate <= endDate.Date)
        }

        public async Task<Result<Agent>> EditAgent(Agent agent)
        {
            var toEdit = await _context.Agents.FirstOrDefaultAsync(x => x.AgentId == agent.AgentId);
            agent.StaffId = _authService.GetStaffID();
            agent.LocationId = Convert.ToInt16(_authService.GetLocationID());
            //_context.Agents.Update(agent);
            toEdit.Name = agent.Name;
            toEdit.Commission = agent.Commission;
            toEdit.Region = agent.Region;
            toEdit.Phone = agent.Phone;
            toEdit.Email = agent.Email;

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

        public async Task<IEnumerable<AgentGameCommissionDto>> GetAgentGameCommissions(string id)
        {
            var list = await _context.AgentGameCommissions.ToListAsync();
            var result =  (from l in list
                          join a in _context.Agents on l.AgentId equals a.AgentId
                          join g in _context.Games on l.GameId equals g.Id
                          where l.AgentId == id

                          select new AgentGameCommissionDto
                          {
                              Id = l.Id,
                              AgentId = l.AgentId,
                              Agent = a.Name,
                              GameId = g.Id,
                              Game = g.Name,
                              Commission = l.Commission
                          }).ToList();
            return result;

        }

        public async Task<Result> AddCommission(AgentGameCommissionDto commission)
        {           
            var exits = await _context.AgentGameCommissions.Where(x => x.AgentId == commission.AgentId && x.GameId == commission.GameId).ToListAsync();
            if (exits.Any())
            {
                return new Result(false, "This game has already been added");
            }
            await _context.AgentGameCommissions.AddAsync(new Shared.AgentGameCommission
            {
                AgentId = commission.AgentId,
                GameId = commission.GameId,
                Commission = commission.Commission,
            });
            if(await _context.SaveChangesAsync()>0)
                return new Result(true, "Game Commission Added Successfully");
            return new Result(false, "An Error Occured While Adding New Commission");
        }

        public async Task<Result> EditCommission(AgentGameCommissionDto commission)
        {
            var result = await _context.AgentGameCommissions.Where(x => x.AgentId == commission.AgentId && x.GameId == commission.GameId).FirstOrDefaultAsync();
            if (result != null)
            {
                result.Commission = commission.Commission;
                if (await _context.SaveChangesAsync() > 0)
                    return new Result(true, "Game Commission Added Successfully");
                return new Result(false, "An Error Occured While Adding New Commission");
            }
            return new Result(false, "Record not found");

        }
        public async Task<decimal?> GetSalesCommission(string agentId, string gameId)
        {
            var result = await _context.AgentGameCommissions.Where(x => x.AgentId == agentId && x.GameId == gameId).FirstOrDefaultAsync();
            if(result != null)
            {
                return result.Commission;
            }
            return 0;
        }

        public IEnumerable<SalesDto2> Join(List<SalesDto2> sales, List<WinsDto> wins)
        {
            foreach (var (s, w) in from s in sales
                                   let w = wins.Where(x => x.SalesId == s.Id)
                                   select (s, w))
            {
                if (w != null)
                {
                    yield return new SalesDto2
                    (
                      s.AccountId,
                      s.AgentId,
                      s.DailySales,
                      s.Description,
                      s.EntryDate,
                      s.DrawDate,
                      w.Sum(x=>x.WinAmount),
                      s.GameId,
                      s.ReceiptNumber,
                      s.Id
                    );
                }
                else
                    yield return new SalesDto2
                    (
                      s.AccountId,
                      s.AgentId,
                      s.DailySales,
                      s.Description,
                      s.EntryDate,
                      s.DrawDate,
                      0,
                      s.GameId,
                      s.ReceiptNumber,
                      s.Id
                    );
            }
        }


    }
}
