using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAccountService
    {
        public Task<Shared.IResult> AddAccount(Account account);
        public Task<IEnumerable<AccountDto>> GetAccounts();
    }
}
