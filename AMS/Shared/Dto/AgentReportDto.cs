using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AgentReportDto
    {
        public string? AgentId { get; set; }
        public string? Name { get; set; }
        public decimal Sales { get; set; }
        public decimal PayInAmount { get; set; }
        public decimal OutstandingBalance { get; set; }
    }
}
