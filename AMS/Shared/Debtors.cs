using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AMS.Shared
{
    public class Debtors
    {
        public Debtors()
        {
            Id = Guid.NewGuid().ToString();
            LastUpdated = DateTime.Now;
        }

        
        public string? Id { get; set; }
        [Required]
        public decimal Debt { get; set; }
        public string? AgentId { get; set; }
        public DateTime LastUpdated { get; set; }
       
    }
}
