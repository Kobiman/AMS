using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

namespace AMS.Server.Services
{
    public class AdministrativeTransactionService : IAdministrativeTransactionService
    {
        public AdministrativeTransactionService(ApplicationDbContext _appDbContext)
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
        public async Task<AdministrativeTransactionDto> AddAdministrativeTransaction(AccountTransaction accountTransaction)
        {
            accountTransaction.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
            accountTransaction.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;

            var result = appDbContext.AccountTransactions.Add(accountTransaction);
            if (await appDbContext.SaveChangesAsync() > 0)
                return await GetAdministrativeTransactionById(result.Entity.Id);
            return null;
        }

        public async Task<AdministrativeTransactionDto> DeleteAdministrativeTransaction(string accountTransactionId)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransactionId);
            if (result != null)
            {
                appDbContext.AccountTransactions.Remove(result);
                await appDbContext.SaveChangesAsync();
                return await GetAdministrativeTransactionById(result.Id);
            }
            return null;
        }

        public async Task<IEnumerable<AdministrativeTransactionDto>> GetAdmininistrativeTransactions(string period)
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
                                join sa in appDbContext.Accounts on t.SecondaryAccountId equals sa.AccountId into gj
                                from x in gj.DefaultIfEmpty()
                                where t.TransactionType == "Administrative"
                                && (t.TransactionDate >= startDate.Date && t.TransactionDate <= endDate.Date)

                                select new AdministrativeTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    SourceAccount = a.AccountName,
                                    SecondaryAccountId = t.SecondaryAccountId,
                                    DestinationAccount = (x == null ? String.Empty : x.AccountName),
                                    Id = t.Id,
                                    Amount = t.Amount,
                                    Credit = t.Credit,
                                    Debit = t.Debit,
                                    Description = t.Description,
                                    TransactionDate = t.TransactionDate
                                }).ToListAsync();
            return result;
        }

        public async Task<AdministrativeTransactionDto> UpdateAdministrativeTrasaction(AccountTransaction accountTransaction)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransaction.Id);
            if (result != null)
            {
                result.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
                result.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;
                result.Amount = accountTransaction.Amount;
                result.Description = accountTransaction.Description;
                result.AccountId = accountTransaction.AccountId;
                result.SecondaryAccountId = accountTransaction.SecondaryAccountId;
                result.TransactionDate = accountTransaction.TransactionDate;

                await appDbContext.SaveChangesAsync();
                return await GetAdministrativeTransactionById(result.Id);
            }
            return null;
        }

       
        public async Task<AdministrativeTransactionDto> GetAdministrativeTransactionById(string transactionID)
        {
            var result = await (from t in appDbContext.AccountTransactions
                                join a in appDbContext.Accounts on t.AccountId equals a.AccountId
                                join sa in appDbContext.Accounts on t.SecondaryAccountId equals sa.AccountId into gj
                                from x in gj.DefaultIfEmpty()
                                where t.Id == transactionID

                                select new AdministrativeTransactionDto
                                {
                                    AccountId = a.AccountId,
                                    SourceAccount = a.AccountName,
                                    SecondaryAccountId = t.SecondaryAccountId,
                                    DestinationAccount = (x == null ? String.Empty : x.AccountName),
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
    }
}
