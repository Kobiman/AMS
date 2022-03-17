using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface ISalesService
    {
        //public Task<Shared.IResult> AddAccountTransaction(AccountTransaction agentsTransaction);
        public Task<SalesDto> AddSales(SalesDto agentsTransaction);
        public Task<IEnumerable<SalesDto>> GetAgentsTransaction(string period);
        public Task<IEnumerable<SalesDto>> GetTransactionsCashInCashOut(string inOut, string period);
        public Task<SalesDto> UpdateAgentsTrasaction(Sales agentsTransaction);  
        public Task<SalesDto> DeleteAgentsTransaction(string agentsTransactionId);
        public Task <IEnumerable<Sales>> GetTransactionsByAccountId(string accountId);          
        public Task<SalesDto> GetTransactionById(string transactionID);
        //GetAdministrativeTransactionById
        public Task<Sales> GetTransaction(string transactionID);
    }
}
