using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Payout
    {
        public Payout()
        {
            Id = Guid.NewGuid().ToString();
            TransactionDate = DateTime.Now;

        }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? AgentId { get; set; }
        public string? GameId { get; set; }

        [Required]
        public string? SourceAccountId { get; set; }
        public string? DestinationAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
