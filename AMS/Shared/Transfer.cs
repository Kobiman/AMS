using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Transfer
    {
        public Transfer()
        {
            Id = Guid.NewGuid().ToString();
            TransactionDate = DateTime.Now;
        }
        public string Id { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? SourceAccountId { get; set; }
        public string? DestinationAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
