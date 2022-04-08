using AMS.Server.Data;
using AMS.Shared;
using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shared.IResult> AddAccount(Account account)
        {
            var originalAccount = _context.Accounts.FirstOrDefault(x=>x.AccountName == account.AccountName);
            if (originalAccount != null) return new Result(false,$"Account with name {account.AccountName} already exist.");
            var count = await _context.Accounts.Where(x => x.Type == account.Type).CountAsync();
            account.Code = AccountConfig.GetAccountCode(account, count);
            _context.Accounts.Add(account);
            var result = await _context.SaveChangesAsync();
            if(result > 0) return new Result(true, "Account saved successfully.");
            return new Result(false, "Operation failled.");
        }

        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            var accounts = await _context.Accounts.Include(x=>x.Transactions).ToListAsync();
            return accounts.Select(x => new AccountDto
            (
                 x.AccountName,
                 x.AccountId,
                 x.Type,
                 x.Transactions.Sum(x=>x.Amount),
                 x.CreatedDate,
                 x.Code
                 )); 
        }
    }
}
