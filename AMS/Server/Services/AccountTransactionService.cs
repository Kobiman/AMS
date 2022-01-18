using AMS.Server.Data;
using AMS.Shared;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class AccountTransactionService : IAccountTransactionService
    {
        public AccountTransactionService(ApplicationDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        private readonly ApplicationDbContext appDbContext;

        public async Task<Shared.IResult> AddAccountTransaction(AccountTransaction accountTransaction)
        {
            if(accountTransaction.Account != null)
            {
                appDbContext.Entry(accountTransaction.Account).State = EntityState.Unchanged;
                accountTransaction.AccountId = accountTransaction.Account.AccountId;
            }
            var result = await appDbContext.AccountTransactions.AddAsync(accountTransaction);
            await appDbContext.SaveChangesAsync();
            if (result != null)
            {
                return new Result(true, "Transaction saved successfully.");
            }
            return new Result(false, "Operation failled.");
        }

        public async Task DeleteAccountTransaction(string accountTransactionId)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransactionId);
            if(result != null)
            {
                appDbContext.AccountTransactions.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<AccountTransaction>> GetAccountTransactions()
        {
            return await appDbContext.AccountTransactions
                .Include(x => x.Account)
                .ToListAsync();

            //return await appDbContext.AccountTransactions
            //    .ToListAsync();
        }

        public async Task<AccountTransaction> UpdateAccountTrasaction(AccountTransaction accountTransaction)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransaction.Id);
            if(result != null)
            {
                result.Account = accountTransaction.Account;
                result.Credit = accountTransaction.Credit;
                result.Debit = accountTransaction.Debit;
                result.Description = accountTransaction.Description;
                result.AccountId = accountTransaction.AccountId;
                result.TransactionDate = accountTransaction.TransactionDate;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<AccountTransaction>> GetTransactionsByAccountId(string accountId)
        {
            var result = await appDbContext.AccountTransactions.Where(i => i.AccountId == accountId).ToListAsync();
            return result;
        }
    }
}
