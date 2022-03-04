using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class AccountTransaction
    {
        public AccountTransaction()
        {
            Id = Guid.NewGuid().ToString();
            TransactionDate = DateTime.Now;
        }
        public string? Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string? Description { get; set; }
        public string? AccountId { get; set; }
        public string? AgentId { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
