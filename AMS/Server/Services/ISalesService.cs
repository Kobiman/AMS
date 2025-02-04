using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface ISalesService
    {
        //public Task<Shared.IResult> AddAccountTransaction(AccountTransaction agentsTransaction);
        public Task<SalesDto> AddSales(SalesDto sales);
        //public Task UpdateSales(SalesDto sales);
        public Task<IEnumerable<SalesDto>> GetSalesReport(DateRange period);
        public Task<IEnumerable<SalesDto>> GetWinsReport(DateRange period);
        public Task<IEnumerable<SalesDto>> GetTransactionsCashInCashOut(string inOut, DateRange period);
        public Task<SalesDto> AddWins(Wins wins);  
        public Task<SalesDto> ApproveSales(string SalesId);  
        public Task<SalesDto> DeleteAgentsTransaction(string agentsTransactionId);
        public Task <IEnumerable<Sales>> GetTransactionsByAccountId(string accountId);          
        public Task<SalesDto> GetTransactionById(string transactionID);
        //GetAdministrativeTransactionById
        public Task<Sales> GetTransaction(string transactionID);
        public Task<IEnumerable<SalesDto>> GetOpenSalesWinsStortage();       
    }
}
