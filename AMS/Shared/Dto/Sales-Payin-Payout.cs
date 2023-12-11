using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
   public record Sales_Payin_Payout
        (
          string AccountId,
          string AgentId, 
          decimal DailySales,
          string Description, 
          DateTime? EntryDate, 
          DateTime? DrawDate, 
          decimal WinAmount, 
          string ReceiptNumber, 
          decimal PayinAmount, 
          decimal PayoutAmount, 
          decimal ExpenseAmount
       );
}
