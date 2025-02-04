using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class SalesDto
    {
        public decimal Amount { get; set; }
        public string? AccountId { get; set; }
        public string? AccountName { get; set; }
        public string AgentName { get; set; } = "";
        public string AgentPhoneNumber { get; set; } = "";
        public string? SalesId { get; set; }
        [Required]
        public decimal WinAmount { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? AgentId { get; set; }
        public string GameId { get; set; }
        public string GameName { get; set; } = "";
        public DateTime? EntryDate { get; set; }
        public DateTime? DrawDate { get; set; }
        [Required]
        public decimal DailySales { get; set; }
        public int NumberOfBooks { get; set; }
        public string? Sheet {  get; set; }
        public int NumberOfSheets { get; set; }
        public string? ReceiptNumber { get; set; } = "";
        public decimal OutstandingBalance { get; set; }
        public string SalesStaffId { get; set; } = string.Empty;
        public string WinsStaffId { get; set; } = string.Empty;
        public bool Approved { get; set; } = false;
        public string SalesTreatedBy { get; set; } = string.Empty;
        public string SalesApprovedBy { get; set; } = string.Empty;
        //public string WinsTreatedBy { get; set; } = string.Empty;
        //public string WinsApprovedBy { get; set; } = string.Empty;
        public string AreaOfOperations { get; set; } = string.Empty;
        public decimal GrossSales { get; set; }
        public decimal SalesCommission { get; set; }
        public decimal SalesCommissionValue { get; set; }
        public int LocationId { get; set; }
        public string? FilePath { get; set; }
    }
}
