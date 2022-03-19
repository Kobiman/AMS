using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class SalesService : ISalesService
    {
        public SalesService(ApplicationDbContext _appDbContext)
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
        public async Task<SalesDto> AddSales(SalesDto sales)
        {
            var result = appDbContext.Sales.Add(
                new Sales { AgentId = sales.AgentId,
                    DailySales = sales.DailySales, 
                    Description = sales.Description,
                    PayInAmount = sales.PayInAmount, 
                    GameId = sales.GameId,
                    ReceiptNumber = sales.ReceiptNumber }
                );

            appDbContext.AccountTransactions.Add(
                new AccountTransaction { AccountId = sales.AccountId, 
                Amount = sales.PayInAmount, 
                Credit = sales.PayInAmount, 
                Description = sales.Description }
                );
            if (await appDbContext.SaveChangesAsync() > 0)
            {
                return await GetTransactionById(result.Entity.Id); 
            }
                
            return null;
        }

        public async Task<SalesDto> DeleteAgentsTransaction(string accountTransactionId)
        {
            var result = await appDbContext.Sales.FirstOrDefaultAsync(i => i.Id == accountTransactionId);
            if (result != null)
            {
                appDbContext.Sales.Remove(result);
                appDbContext.AccountTransactions.Add(
                new AccountTransaction
                {
                    AccountId = "",
                    Amount = -result.PayInAmount,
                    Debit = result.PayInAmount,
                    Description = "Transaction removed"
                }
                );
                await appDbContext.SaveChangesAsync();
                //await UpdateAccount(-result.PayInAmount, result.AccountId);
                return await GetTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<SalesDto>> GetAgentsTransaction(string period)
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
            var result = await (from t in appDbContext.Sales
                                //join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                where
                                t.TransactionDate >= startDate.Date && t.TransactionDate <= endDate.Date

                                select new SalesDto
                                {
                                    //AccountId = t.AccountId,
                                    //AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    AgentName = x == null ? string.Empty : x.Name,
                                    Id = t.Id,
                                    Amount = t.PayInAmount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.PayInAmount,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate,
                                    GameId = t.GameId,
                                    GameName = gme == null? string.Empty : gme.Name,
                                }).ToListAsync();
            return result;
        }

    

        public async Task<SalesDto> UpdateAgentsTrasaction(Sales agentTransaction)
        {
            string preAccountId;
            decimal preAmount;
            var result = await appDbContext.Sales.FirstOrDefaultAsync(i => i.Id == agentTransaction.Id);
            if (result != null)
            {
                //preAccountId = result.AccountId;
                preAmount = result.PayInAmount;
                result.PayInAmount = agentTransaction.PayInAmount;
                result.Description = agentTransaction.Description;
                //result.AccountId = agentTransaction.AccountId;
                result.AgentId = agentTransaction.AgentId;
                result.DailySales = agentTransaction.DailySales;
                result.TransactionDate = agentTransaction.TransactionDate;
                //result.TransactionType = "Agent";

                //update account balance
                //if (preAccountId  == agentTransaction.AccountId)
                //{
                //    var accToUpdate = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == result.AccountId);
                //    if (accToUpdate != null)
                //    {
                //        accToUpdate.Balance -= preAmount;
                //        await appDbContext.SaveChangesAsync();
                //        accToUpdate.Balance += result.PayInAmount;
                //        await appDbContext.SaveChangesAsync();
                //    }
                //}
                //else
                //{
                //    var accToUpdate1 = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == result.AccountId);
                //    if (accToUpdate1 != null)
                //    {
                //        accToUpdate1.Balance += result.PayInAmount;
                //        await appDbContext.SaveChangesAsync();
                //    }
                //    var accToUpdate2 = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == preAccountId);
                //    if (accToUpdate2 != null)
                //    {
                //        accToUpdate2.Balance -= preAmount;
                //        await appDbContext.SaveChangesAsync();
                //    }
                //}

                await appDbContext.SaveChangesAsync();
                return await GetTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<Sales>> GetTransactionsByAccountId(string accountId)
        {
            List<Sales> transactions = await appDbContext.Sales.Where(t => t.AgentId == accountId).ToListAsync();
            return transactions;
        }

        private IEnumerable<SalesDto> CreateTransaction(List<Account> accounts)
        {
            foreach (var a in accounts)
            {
                foreach (var t in a.Transactions)
                {
                    yield return new SalesDto
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

        public async Task<SalesDto> GetTransactionById(string transactionID)
        {
            var result = await (from t in appDbContext.Sales
                                //join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                where t.Id == transactionID

                                select new SalesDto
                                {
                                    //AccountId = a.AccountId,
                                    //AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    AgentName = (x == null? String.Empty : x.Name),
                                    Id = t.Id,
                                    Amount = t.PayInAmount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.PayInAmount,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate,
                                    GameId = t.GameId,
                                    GameName = gme == null ? string.Empty : gme.Name,
                                }).FirstOrDefaultAsync();

            return result;
        }

       

        public async Task<Sales> GetTransaction(string transactionID)
        {
            return await appDbContext.Sales.FirstOrDefaultAsync(t => t.Id == transactionID);
        }

        public async Task<IEnumerable<SalesDto>> GetTransactionsCashInCashOut(string inOut, string period)
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
