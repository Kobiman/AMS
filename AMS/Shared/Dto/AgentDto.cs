using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AgentDto
    {

        public string? AgentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Contact { get; set; }
        public decimal Sales { get; set; }

        public decimal AmountPaid { get; set; }

        public decimal OutstandingBalance { get; set; }
    }
}
