using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAccountService
    {
        public Task<Shared.IResult> AddAccount(Account account);
        public Task<IEnumerable<AccountDto>> GetAccounts();
        Task<IEnumerable<IncomeStatementDto>> GetIncomeStatement(int date);
        Task<IEnumerable<IncomeStatementDto>> GetBalanceSheet(int year);
        Task<IEnumerable<TrialBalanceDto>> GetTrialBalance(int year);
    }
}
