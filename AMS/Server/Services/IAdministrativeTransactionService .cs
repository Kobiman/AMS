using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAdministrativeTransactionService
    {
        //public Task<Shared.IResult> AddAccountTransaction(AccountTransaction accountTransaction);
        public Task<AdministrativeTransactionDto> AddAdministrativeTransaction(AccountTransaction accountTransaction);
        public Task<IEnumerable<AdministrativeTransactionDto>> GetAdmininistrativeTransactions(string period); 
        public Task<AdministrativeTransactionDto> UpdateAdministrativeTrasaction(AccountTransaction accountTransaction);
        public Task<AdministrativeTransactionDto> DeleteAdministrativeTransaction(string accountTransactionId);

        public Task<AdministrativeTransactionDto> GetAdministrativeTransactionById(string transactionID);

        public Task<AccountTransaction> GetTransaction(string transactionID);

    }
}
