using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
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
            accountTransaction.Debit = accountTransaction.Amount < 0 ? accountTransaction.Amount : 0;
            accountTransaction.Credit = accountTransaction.Amount > 0 ? accountTransaction.Amount : 0;
            appDbContext.AccountTransactions.Add(accountTransaction);
            var result = await appDbContext.SaveChangesAsync();
            if (result > 0)
                return new Result(true, "Transaction saved successfully.");
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

        public async Task<IEnumerable<AccountTransactionDto>> GetAccountTransactions()
        {
            var accounts = await appDbContext.Accounts.Include(x => x.Transactions).ToListAsync();
            return CreateTransaction(accounts);
        }

        public async Task<AccountTransaction> UpdateAccountTrasaction(AccountTransaction accountTransaction)
        {
            var result = await appDbContext.AccountTransactions.FirstOrDefaultAsync(i => i.Id == accountTransaction.Id);
            if(result != null)
            {
                result.AccountId = accountTransaction.AccountId;
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
                        Amount = t.Amount,
                        Credit = t.Credit,
                        Debit = t.Debit,
                        Description = t.Description,
                        TransactionDate = t.TransactionDate
                    };
                }
            }
        }
    }
}
