using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public record SalesDetails(
        string? AccountId, 
        string? AgentId,
        string? Name, 
        decimal DailySales,
        string? Description,
        DateTime? EntryDate,
        DateTime? DrawDate,
        decimal WinAmount,
        string? ReceiptNumber,
        decimal OpeningBalance,
        decimal EndBalance,
        decimal PayinAmount,
        decimal PayoutAmount,
        decimal ExpenseAmount,
        string Game);
}
