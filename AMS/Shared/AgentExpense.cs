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
    public class AgentExpense
    {
        public AgentExpense()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? AgentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }   
        public string? GameId { get; set; }
        public string? SalesId { get; set; }
        public DateTime EntryDate { get; set; }
        public string StaffId { get; set; } = string.Empty;
        //public string TreatedBy { get; set; } = string.Empty;
    }
}
