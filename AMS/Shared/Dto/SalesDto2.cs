using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
   public record SalesDto2(
       string AccountId,
       string AgentId, 
       decimal DailySales, 
       string Description, 
       DateTime? EntryDate, 
       DateTime? DrawDate, 
       decimal WinAmount, 
       string GameId, 
       string ReceiptNumber,
       string Id);
   public record WinsDto(decimal WinAmount,string SalesId);
}
