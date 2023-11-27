using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AgentDto
    {

        public string? AgentId { get; set; }
        public DateTime? CreatedDate { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? HouseNo { get; set; }
        public bool Approved { get; set; }
        public decimal Sales { get; set; }

        public decimal Commision { get; set; }
        public decimal AmountPaid { get; set; }

        public decimal OutstandingBalance { get; set; }
    }
}
