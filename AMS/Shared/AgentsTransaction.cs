using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AMS.Shared
{
    public class AgentsTransaction
    {
        public AgentsTransaction()
        {
            Id = Guid.NewGuid().ToString();
            TransactionDate = DateTime.Now;
        }

        
        public string? Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? AccountId { get; set; }
        [Required]
        public string? AgentId { get; set; }
        public DateTime? TransactionDate { get; set; }

        public string? TransactionType { get; set; }
        public decimal DailySales { get; set; }
    }
}
