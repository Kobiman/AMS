using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAdministrativeTransactionService
    {
        //public Task<Shared.IResult> AddAccountTransaction(AdminTransactions adminTransaction);
        public Task<AdministrativeTransactionDto> AddAdministrativeTransaction(AdminTransaction adminTransaction);
        public Task<IEnumerable<AdministrativeTransactionDto>> GetAdmininistrativeTransactions(string period); 
        public Task<AdministrativeTransactionDto> UpdateAdministrativeTrasaction(AdminTransaction adminTransaction);
        public Task<AdministrativeTransactionDto> DeleteAdministrativeTransaction(string accountTransactionId);

        public Task<AdministrativeTransactionDto> GetAdministrativeTransactionById(string transactionID);

        public Task<AdminTransaction> GetTransaction(string transactionID);

    }
}
