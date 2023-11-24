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
    public class AgentExpenseDto
    {
        public string? Id { get; set; }
        public string? AgentId { get; set; }
        public string Agent { get; set; }   
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }

        public string? Description { get; set; }   
        public string? SalesId { get; set; }
        public DateTime? EntryDate { get; set; } = DateTime.Now;
        public string StaffId { get; set; } = string.Empty;
        //public string TreatedBy { get; set; } = string.Empty;
    }
}
