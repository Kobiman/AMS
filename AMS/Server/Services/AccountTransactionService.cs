using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AMS.Server.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {
        public AccountTransactionService(ApplicationDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        private readonly ApplicationDbContext appDbContext;

        //public async Task<Shared.IResult> AddAccountTransaction(AccountTransaction accountTransaction)
        //{
        //    accountTransaction.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
        //    accountTransaction.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;
        //    appDbContext.AccountTransactions.Add(accountTransaction);
        //    var result = await appDbContext.SaveChangesAsync();
        //    if (result > 0)
        //        return new Result(true, "Transaction saved successfully.");
        //    return new Result(false, "Operation failled.");
        //}
        public async Task<AccountTransactionDto> AddAccountTransaction(AccountTransaction accountTransaction)
        {
            accountTransaction.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
            accountTransaction.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;
            var result = appDbContext.AccountTransactions.Add(accountTransaction);
            if (await appDbContext.SaveChangesAsync() > 0)
                return await GetTransactionById(result.Entity.Id);
            return null;
        }

        public async Task<AccountTransactionDto> DeleteAccountTransaction(string accountTransactionId)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransactionId);
            if (result != null)
            {
                appDbContext.AccountTransactions.Remove(result);
                await appDbContext.SaveChangesAsync();
                return await GetTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<AccountTransactionDto>> GetAccountTransactions(string period)
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
            var result = await (from t in appDbContext.AccountTransactions
                                join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId
                                where t.TransactionDate >= startDate.Date && t.TransactionDate <= endDate.Date

                                select new AccountTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    AccountName = a.AccountName,
                                    AgentId = ag.AgentId,
                                    Agent = ag.Name,
                                    Id = t.Id,
                                    Amount = t.Amount,
                                    Credit = t.Credit,
                                    Debit = t.Debit,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate
                                }).ToListAsync();
            return result;
        }

        public async Task<AccountTransactionDto> UpdateAccountTrasaction(AccountTransaction accountTransaction)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransaction.Id);
            if (result != null)
            {
                result.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
                result.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;
                result.Amount = accountTransaction.Amount;
                result.Description = accountTransaction.Description;
                result.AccountId = accountTransaction.AccountId;
                result.TransactionDate = accountTransaction.TransactionDate;

                await appDbContext.SaveChangesAsync();
                return await GetTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByAccountId(string accountId)
        {
            List<AccountTransaction> transactions = await appDbContext.AccountTransactions.Where(t => t.AccountId == accountId).ToListAsync();
            return transactions;
        }

        private IEnumerable<AccountTransactionDto> CreateTransaction(List<Account> accounts)
        {
            foreach (var a in accounts)
            {
                foreach (var t in a.Transactions)
                {
                    yield return new AccountTransactionDto
                    {
                        AccountId = a.AccountId,
                        AccountName = a.AccountName,
                        Id = t.Id,
                        Amount = t.Amount,
                        Credit = t.Credit,
                        Debit = t.Debit,
                        Description = t.Description,
                        TransactionDate = t.TransactionDate
                    };
                }
            }
        }

        public async Task<AccountTransactionDto> GetTransactionById(string transactionID)
        {
            var result = await (from t in appDbContext.AccountTransactions
                                join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join ag in appDbContext.Agents on t.AgentId equals ag.AgentId
                                where t.Id == transactionID

                                select new AccountTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    AccountName = a.AccountName,
                                    AgentId = ag.AgentId,
                                    Agent = ag.Name,
                                    Id = t.Id,
                                    Amount = t.Amount,
                                    Credit = t.Credit,
                                    Debit = t.Debit,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate
                                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task<AccountTransaction> GetTransaction(string transactionID)
        {
            return await appDbContext.AccountTransactions.FirstOrDefaultAsync(t => t.Id == transactionID);
        }

        public async Task<IEnumerable<AccountTransactionDto>> GetTransactionsCashInCashOut(string inOut, string period)
        {
            var transactions = await GetAccountTransactions(period);
            if (inOut == "CashIn")
                return transactions.Where(x => x.Amount > 0);
            else
                return transactions.Where(x => x.Amount < 0);
        }
    }
}
