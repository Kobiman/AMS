using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAccountTransactionService
    {
        Task<Shared.IResult> AddAccountTransaction(AddTransactionDto adminTransactions);
        public Task<AccountTransactionDto> AddAdministrativeTransaction(AccountTransaction adminTransaction);
        public Task<IEnumerable<AccountTransactionDto>> GetAdmininistrativeTransactions(string period); 
        public Task<AccountTransactionDto> UpdateAdministrativeTrasaction(AccountTransaction adminTransaction);
        public Task<AccountTransactionDto> DeleteAdministrativeTransaction(string accountTransactionId);

        public Task<AccountTransactionDto> GetAdministrativeTransactionById(string transactionID);

        public Task<AccountTransaction> GetTransaction(string transactionID);
        public Task<AccountTransactionDto> Transfer(TransferDto transferDto);
        public Task<IEnumerable<TransferDto>> TransferReport(string period);
        public Task<AccountTransactionDto> Payout(AddPayoutDto addPayoutDto);
        public Task<IEnumerable<PayoutDto>> PayoutReport(string period);
    }
}
