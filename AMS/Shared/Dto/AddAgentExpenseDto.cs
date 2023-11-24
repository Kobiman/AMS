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
    public class AddAgentExpenseDto
    {

        [Required]
        public string? AgentId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public string? Description { get; set; }   
        public string? SalesId { get; set; }

        [Required]
        public DateTime? EntryDate { get; set; } = DateTime.Now;
        public string StaffId { get; set; } = string.Empty;
        //public string TreatedBy { get; set; } = string.Empty;
    }
}
