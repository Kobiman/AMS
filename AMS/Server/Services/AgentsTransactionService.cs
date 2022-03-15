using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class AgentsTransactionService : IAgentsTransactionService
    {
        public AgentsTransactionService(ApplicationDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        private readonly ApplicationDbContext appDbContext;

        //public async Task<Shared.IResult> AddAccountTransaction(AccountTransaction accountTransaction)
        //{
        //    accountTransaction.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
        //    accountTransaction.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;
        //    appDbContext.AgentsTransactions.Add(accountTransaction);
        //    var result = await appDbContext.SaveChangesAsync();
        //    if (result > 0)
        //        return new Result(true, "Transaction saved successfully.");
        //    return new Result(false, "Operation failled.");
        //}
        public async Task<AgentsTransactionDto> AddAgentsTransaction(AgentsTransaction accountTransaction)
        {
            var result = appDbContext.AgentsTransactions.Add(accountTransaction);
            if (await appDbContext.SaveChangesAsync() > 0)
            {
                await UpdateAccount(accountTransaction.Amount, accountTransaction.AccountId);
                return await GetTransactionById(result.Entity.Id); 
            }
                
            return null;
        }

        public async Task<AgentsTransactionDto> DeleteAgentsTransaction(string accountTransactionId)
        {
            var result = await appDbContext.AgentsTransactions.FirstOrDefaultAsync(i => i.Id == accountTransactionId);
            if (result != null)
            {
                appDbContext.AgentsTransactions.Remove(result);
                await appDbContext.SaveChangesAsync();
                await UpdateAccount(-result.Amount, result.AccountId);
                return await GetTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<AgentsTransactionDto>> GetAgentsTransaction(string period)
        {
            DateTime date = DateTime.Now.Date;
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if (period == "This Week")
            {
                startDate = date.AddDays(-(int)date.DayOfWeek + (int)DayOfWeek.Sunday);
                endDate = startDate.AddDays(6);
            }

            else if (period == "This Month")
            {
                startDate = new DateTime(date.Year, date.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                endDate = startDate.AddDays(daysInMonth - 1);
            }
            else
            {
                startDate = date.Date;
                endDate = date.AddHours(24);
            }
            var result = await (from t in appDbContext.AgentsTransactions
                               join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                where t.TransactionType == "Agent"
                                && (t.TransactionDate >= startDate.Date && t.TransactionDate <= endDate.Date)

                                select new AgentsTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    Agent = (x == null ? String.Empty : x.Name),
                                    Id = t.Id,
                                    Amount = t.Amount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.Amount,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate
                                }).ToListAsync();
            return result;
        }

    

        public async Task<AgentsTransactionDto> UpdateAgentsTrasaction(AgentsTransaction agentTransaction)
        {
            string preAccountId;
            decimal preAmount;
            var result = await appDbContext.AgentsTransactions.FirstOrDefaultAsync(i => i.Id == agentTransaction.Id);
            if (result != null)
            {
                preAccountId = result.AccountId;
                preAmount = result.Amount;
                result.Amount = agentTransaction.Amount;
                result.Description = agentTransaction.Description;
                result.AccountId = agentTransaction.AccountId;
                result.AgentId = agentTransaction.AgentId;
                result.DailySales = agentTransaction.DailySales;
                result.TransactionDate = agentTransaction.TransactionDate;
                result.TransactionType = "Agent";

                //update account balance
                if (preAccountId  == agentTransaction.AccountId)
                {
                    var accToUpdate = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == result.AccountId);
                    if (accToUpdate != null)
                    {
                        accToUpdate.Balance -= preAmount;
                        await appDbContext.SaveChangesAsync();
                        accToUpdate.Balance += result.Amount;
                        await appDbContext.SaveChangesAsync();
                    }
                }
                else
                {
                    var accToUpdate1 = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == result.AccountId);
                    if (accToUpdate1 != null)
                    {
                        accToUpdate1.Balance += result.Amount;
                        await appDbContext.SaveChangesAsync();
                    }
                    var accToUpdate2 = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == preAccountId);
                    if (accToUpdate2 != null)
                    {
                        accToUpdate2.Balance -= preAmount;
                        await appDbContext.SaveChangesAsync();
                    }
                }

                await appDbContext.SaveChangesAsync();
                return await GetTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<AgentsTransaction>> GetTransactionsByAccountId(string accountId)
        {
            List<AgentsTransaction> transactions = await appDbContext.AgentsTransactions.Where(t => t.AccountId == accountId).ToListAsync();
            return transactions;
        }

        private IEnumerable<AgentsTransactionDto> CreateTransaction(List<Account> accounts)
        {
            foreach (var a in accounts)
            {
                foreach (var t in a.Transactions)
                {
                    yield return new AgentsTransactionDto
                    {
                        AccountId = a.AccountId,
                        AccountName = a.AccountName,
                        Id = t.Id,
                        Amount = t.Amount,
                        Description = t.Description,
                        TransactionDate = t.TransactionDate
                    };
                }
            }
        }

        public async Task<AgentsTransactionDto> GetTransactionById(string transactionID)
        {
            var result = await (from t in appDbContext.AgentsTransactions
                                join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                where t.Id == transactionID

                                select new AgentsTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    Agent = (x == null? String.Empty : x.Name),
                                    Id = t.Id,
                                    Amount = t.Amount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.Amount,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate
                                }).FirstOrDefaultAsync();

            return result;
        }

       

        public async Task<AgentsTransaction> GetTransaction(string transactionID)
        {
            return await appDbContext.AgentsTransactions.FirstOrDefaultAsync(t => t.Id == transactionID);
        }

        public async Task<IEnumerable<AgentsTransactionDto>> GetTransactionsCashInCashOut(string inOut, string period)
        {
            var transactions = await GetAgentsTransaction(period);
            if (inOut == "CashIn")
                return transactions.Where(x => x.Amount > 0);
            else
                return transactions.Where(x => x.Amount < 0);
        }

        public async Task UpdateAccount(decimal amount, string accountId)
        {
            var accToUpdate = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
            if (accToUpdate != null)
            {
                accToUpdate.Balance += amount;
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
