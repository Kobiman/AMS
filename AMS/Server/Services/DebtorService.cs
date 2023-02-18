using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

namespace AMS.Server.Services
{
    public class DebtorService : IDebtorsService
    {
        private readonly ApplicationDbContext dbContext;
        public DebtorService(ApplicationDbContext _dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DebtorsDto> AddDebtor(Debtors debtor)
        {
            var result = await dbContext.Debtors.FirstOrDefaultAsync(x => x.AgentId == debtor.AgentId);
            if(result == null)
            {
                await dbContext.Debtors.AddAsync(debtor);
                dbContext.SaveChangesAsync();
                return await GetDebtorByAgentId(debtor.AgentId);
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<DebtorsDto>> GetDebtors()
        {
            return await (from d in dbContext.Debtors
                              join a in dbContext.Agents on d.AgentId equals a.AgentId

                              select new DebtorsDto
                              {
                                  AgentId = d.AgentId,
                                  Agent = a.Name,
                                  LastUpdated = d.LastUpdated
                              }).ToListAsync();
        }

        public Task<DebtorsDto> UpdateDetor(Debtors debtor)
        {
            throw new NotImplementedException();
        }

        private async Task <DebtorsDto> GetDebtorByAgentId(string agentId)
        {
            return await(from d in dbContext.Debtors
                         join a in dbContext.Agents on d.AgentId equals a.AgentId

                         select new DebtorsDto
                         {
                             AgentId = d.AgentId,
                             Agent = a.Name,
                             LastUpdated = d.LastUpdated
                         }).FirstOrDefaultAsync();
        }
    }
}
