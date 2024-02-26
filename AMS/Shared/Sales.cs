using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AMS.Shared
{
    public class Sales
    {
        public Sales()
        {
            SalesId = Guid.NewGuid().ToString();
            EntryDate = DateTime.Now;
        }

        
        public string? SalesId { get; set; }
        //[Required]
        //public decimal WinAmount { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? AgentId { get; set; }
        public string? AccountId { get; set; }
        public string GameId { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? DrawDate { get; set; }
        public decimal DailySales { get; set; }
        public string? ReceiptNumber { get; set; }
        public string SalesStaffId { get; set; }
        //public string WinsStaffId { get; set; }
        public bool Approved { get; set; } = false;
        public string SalesTreatedBy { get; set; } = string.Empty;
        public string SalesApprovedBy { get; set; } = string.Empty;
        public string AreaOfOperations { get; set; } = string.Empty;
        public int? LocationId { get; set; }
        public int NumberOfBooks { get; set; }
        //public int NumberOfSheets { get; set; }
        public decimal GrossSales { get; set; }
        public decimal SalesCommission { get; set; }
    }

    public class Wins
    {
        public string? Id { get; set; }
        public string? SalesId { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? DrawDate { get; set; }
        [Required]
        public decimal WinAmount { get; set; }
        public string? Sheet { get; set; }
        [Required]
        public string? AgentId { get; set; }
        [Required]
        public string? Description { get; set; }
        public int NumberOfSheets { get; set; }
        public string? StaffId { get; set; }
        public bool Approved { get; set; } = false;
    }
}
