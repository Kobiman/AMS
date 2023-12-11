using AMS.Shared;
using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IAccountTransactionService
    {
        Task<Shared.IResult> AddAccountTransaction(AddTransactionDto adminTransactions);
        public Task<AccountTransactionDto> AddAdministrativeTransaction(AccountTransaction adminTransaction);
        public Task<IEnumerable<AccountTransactionDto>> GetAdmininistrativeTransactions(DateRange period); 
        public Task<AccountTransactionDto> UpdateAdministrativeTrasaction(AccountTransaction adminTransaction);
        public Task<AccountTransactionDto> DeleteAdministrativeTransaction(string accountTransactionId);

        public Task<AccountTransactionDto> GetAdministrativeTransactionById(string transactionID);

        public Task<AccountTransaction> GetTransaction(string transactionID);
        public Task<AccountTransactionDto> Transfer(TransferDto transferDto);
        public Task<IEnumerable<TransferDto>> TransferReport(DateRange period);
        public Task<AccountTransactionDto> Payout(AddPayoutDto addPayoutDto);

        public Task<Result> AddAgentExpense(AddAgentExpenseDto addExpenseDto);
        public Task<Result> EditAgentExpense(AgentExpenseDto editExpenseDto);
        public Task<IEnumerable<AgentExpenseDto>> AgentExpenses(DateRange period);

        public Task<Result> EditPayout(Payout editPayoutDto);
        public Task<Result<AccountTransactionDto>> ApprovePayout(string payoutId);
        public Task<IEnumerable<PayoutDto>> PayoutReport(DateRange period);
        public Task<IEnumerable<PayoutDto>> PayinReport(DateRange period);
    }
}
