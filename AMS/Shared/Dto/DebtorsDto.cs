using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class DebtorsDto
    {
        public string? Id { get; set; }
        public decimal Debt { get; set; }
        public string? AgentId { get; set; }
        public string? Agent { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
