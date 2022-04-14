using AMS.Shared.Dto;

namespace AMS.Server.Services
{
    public interface IExpenseService
    {
        Task<Shared.IResult> AddExpenses(AddExpenseDto expense);
        Task<IEnumerable<GetExpenseDto>> GetExpenses();
    }
}
