using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAccountTransactionService
    {
        public Task<Shared.IResult> AddAccountTransaction(AccountTransaction accountTransaction);
        public Task<IEnumerable<AccountTransactionDto>> GetAccountTransactions();
        public Task<AccountTransaction> UpdateAccountTrasaction(AccountTransaction accountTransaction);
        public Task DeleteAccountTransaction(string accountTransactionId);
        public Task <IEnumerable<AccountTransaction>> GetTransactionsByAccountId(string accountId);
    }
}
