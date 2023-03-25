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
            Id = Guid.NewGuid().ToString();
            EntryDate = DateTime.Now;
        }

        
        public string? Id { get; set; }
        [Required]
        public decimal WinAmount { get; set; }
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
    }
}
