using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AccountTransactionDto
    {
        public string? Id { get; set; }
        public decimal Amount { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string? Description { get; set; }
        public string? AccountId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? AccountName { get; set; }
    }
}
