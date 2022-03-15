using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAgentsTransactionService
    {
        //public Task<Shared.IResult> AddAccountTransaction(AccountTransaction agentsTransaction);
        public Task<AgentsTransactionDto> AddAgentsTransaction(AgentsTransaction agentsTransaction);
        public Task<IEnumerable<AgentsTransactionDto>> GetAgentsTransaction(string period);
        public Task<IEnumerable<AgentsTransactionDto>> GetTransactionsCashInCashOut(string inOut, string period);
        public Task<AgentsTransactionDto> UpdateAgentsTrasaction(AgentsTransaction agentsTransaction);  
        public Task<AgentsTransactionDto> DeleteAgentsTransaction(string agentsTransactionId);
        public Task <IEnumerable<AgentsTransaction>> GetTransactionsByAccountId(string accountId);          
        public Task<AgentsTransactionDto> GetTransactionById(string transactionID);
        //GetAdministrativeTransactionById
        public Task<AgentsTransaction> GetTransaction(string transactionID);
    }
}
