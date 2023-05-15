using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    /// <summary>
    /// Note this class is now also used for both payout and payin
    /// </summary>
    public class Payout
    {
        public Payout()
        {
            Id = Guid.NewGuid().ToString();
            EntryDate = DateTime.Now;
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal Amount { get; set; }
        public decimal PayoutAmount { get; set; }
        public decimal PayinAmount { get; set; }
        public string? Description { get; set; }
        public string? AgentId { get; set; }
        public string? GameId { get; set; }

        //[Required]
        public string? SourceAccountId { get; set; }
        public string? DestinationAccountId { get; set; }
        public string? Type { get; set; }
        public DateTime EntryDate { get; set; }
        //public DateTime DrawDate { get; set; }
    }
}
