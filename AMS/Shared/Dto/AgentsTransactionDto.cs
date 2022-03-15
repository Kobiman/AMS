using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AgentsTransactionDto
    {
        public string? Id { get; set; }
        public decimal Amount { get; set; }

        public string? Description { get; set; }
        public string? AccountId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? AccountName { get; set; }
        public string? AgentId { get; set; } = "";
        public string Agent { get; set; } = "";

        public decimal DailySales { get; set; }

        public decimal OutstandingBalance { get; set; }
    }
}
