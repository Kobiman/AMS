using AMS.Shared.Dto;
using AMS.Shared.Enums;
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
            var cachAccount = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountName.ToUpper() == "Cash-Checking Account".ToUpper());
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

            var Decrease = new JournalEntryRules(expense.Amount, AccountTypes.Asset, JournalEntryRules.Decrease);
            _context.AccountTransactions.Add(
                new AccountTransaction
                {
                    Amount = Decrease.Amount,
                    Credit = Decrease.Credit,
                    Debit = Decrease.Debit,
                    Description = expense.Description,
                    AccountId = cachAccount?.AccountId.ToString()
                });

            _context.Expenses.Add(new Expense {  Amount = expense.Amount, Description = expense.Description, AccountId = expense.AccountId, AgentId = expense.AgentId });
            var result = await _context.SaveChangesAsync();
            if (result > 0) return new Result(true, "Expense saved successfully.");
            return new Result(false, "Operation failed.");
        }

        public async Task<IEnumerable<GetExpenseDto>> GetExpenses()
        {
            var accounts = await _context.Accounts.Select(x=>new {x.AccountId,x.AccountName}).ToDictionaryAsync(x=>x.AccountId,x=>x.AccountName);
            //var agents = await _context.Agents.Select(x => new { x.AgentId, x.Name }).ToDictionaryAsync(x => x.AgentId, x => x.Name);
            var expenses = await _context.Expenses.ToListAsync();
            return expenses.Select(x => new GetExpenseDto {
                Description = x.Description,
                Amount = x.Amount,
                AccountName = accounts.TryGetValue(x.AccountId,out string? accountName)? accountName:"",
                //AgentName = agents.TryGetValue(x.AgentId, out string? agentName) ? agentName : "",
                Date = x.Date 
            });
        }
    }
}
