using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAccountTransactionService
    {
        //public Task<Shared.IResult> AddAccountTransaction(AccountTransaction accountTransaction);
        public Task<AccountTransactionDto> AddAccountTransaction(AccountTransaction accountTransaction);
        public Task<IEnumerable<AccountTransactionDto>> GetAccountTransactions();
        public Task<AccountTransactionDto> UpdateAccountTrasaction(AccountTransaction accountTransaction);
        public Task<AccountTransactionDto> DeleteAccountTransaction(string accountTransactionId);
        public Task <IEnumerable<AccountTransaction>> GetTransactionsByAccountId(string accountId);
        
        public Task<AccountTransactionDto> GetTransactionById(string transactionID);
        public Task<AccountTransaction> GetTransaction(string transactionID);
    }
}
