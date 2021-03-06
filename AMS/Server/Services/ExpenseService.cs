using AMS.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace AMS.Server.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext _context;
        public ExpenseService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Shared.IResult> AddExpenses(AddExpenseDto expense)
        {
            var journalEntryRule = new JournalEntryRules(expense.Amount, expense.AccountType, JournalEntryRules.Increase);
            _context.AccountTransactions.Add(
                new AccountTransaction
                {
                    Amount = journalEntryRule.Amount,
                    Credit = journalEntryRule.Credit,
                    Debit = journalEntryRule.Debit,
                    Description = expense.Description,
                    AccountId = expense.AccountId
                });
            _context.Expenses.Add(new Expense {  Amount = expense.Amount, Description = expense.Description, AccountId = expense.AccountId });
            var result = await _context.SaveChangesAsync();
            if (result > 0) return new Result(true, "Expense saved successfully.");
            return new Result(false, "Operation failled.");
        }

        public async Task<IEnumerable<GetExpenseDto>> GetExpenses()
        {
            var accounts = await _context.Accounts.ToDictionaryAsync(x=>x.AccountId,x=>x.AccountName);
            var expenses = await _context.Expenses.ToListAsync();
            return expenses.Select(x => new GetExpenseDto { Description = x.Description, Amount = x.Amount, AccountName = accounts[x.AccountId], Date = x.Date });
        }
    }
}
