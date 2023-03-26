using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using AMS.Shared.Enums;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;

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
            var cachAccount = await appDbContext.Accounts.FirstOrDefaultAsync(x => x.AccountName.ToUpper() == "Cash-Checking Account".ToUpper());
            var result = appDbContext.Sales.Add(
                new Sales { AgentId = sales.AgentId,
                    AccountId = sales.AccountId,
                    DailySales = sales.DailySales, 
                    Description = sales.Description,
                    WinAmount = sales.WinAmount, 
                    GameId = sales.GameId,
                    ReceiptNumber = sales.ReceiptNumber,
                    EntryDate = sales.EntryDate,
                    DrawDate = sales.DrawDate }
                );

            var Increase = new JournalEntryRules(sales.WinAmount, AccountTypes.Asset, JournalEntryRules.Increase);
            appDbContext.AccountTransactions.Add(
                new AccountTransaction
                {
                    Amount = Increase.Amount,
                    Credit = Increase.Credit,
                    Debit = Increase.Debit,
                    Description = sales.Description,
                    AccountId = cachAccount?.AccountId
                });

            appDbContext.AccountTransactions.Add(
                new AccountTransaction { AccountId = sales.AccountId, 
                Amount = sales.WinAmount, 
                Credit = sales.WinAmount, 
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
                    AccountId = result.AccountId,
                    Amount = -result.WinAmount,
                    Debit = result.WinAmount,
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
            DateRange.GetDates(period,out DateTime sDate,out DateTime eDate);
            DateTime startDate = sDate;
            DateTime endDate = eDate;

            var result = await (from t in appDbContext.Sales
                                //join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId into gj
                                from x in gj.DefaultIfEmpty()
                                join ga in appDbContext.Games on t.GameId equals ga.Id into _gme
                                from gme in _gme.DefaultIfEmpty()
                                where
                                t.EntryDate >= startDate.Date && t.EntryDate <= endDate.Date

                                select new SalesDto
                                {
                                    //AccountId = t.AccountId,
                                    //AccountName = a.AccountName,
                                    AgentId = t.AgentId,
                                    AgentName = x == null ? string.Empty : x.Name,
                                    Id = t.Id,
                                    WinAmount = t.WinAmount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.WinAmount,
                                    Description = t.Description,
                                    EntryDate = t.EntryDate,
                                    DrawDate = t.DrawDate,
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
                preAmount = result.WinAmount;
                result.WinAmount = agentTransaction.WinAmount;
                result.Description = agentTransaction.Description;
                //result.AccountId = agentTransaction.AccountId;
                result.AgentId = agentTransaction.AgentId;
                result.DailySales = agentTransaction.DailySales;
                result.EntryDate = agentTransaction.EntryDate;
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
                        WinAmount = t.Amount,
                        Description = t.Description,
                        EntryDate = t.TransactionDate,
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
                                    WinAmount = t.WinAmount,
                                    DailySales = t.DailySales,
                                    OutstandingBalance = t.DailySales - t.WinAmount,
                                    Description = t.Description,
                                    EntryDate = t.EntryDate,
                                    DrawDate = t.DrawDate,
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
                return transactions.Where(x => x.WinAmount > 0);
            else
                return transactions.Where(x => x.WinAmount < 0);
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
