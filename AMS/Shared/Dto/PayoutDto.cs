using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class PayoutDto
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? AgentId { get; set; }
        public string? GameId { get; set; }
        public string? SourceAccountId { get; set; }
        public string? DestinationAccountId { get; set; }
        public string DestinationAccount { get; set; }
        public string SourceAccount { get; set; }
        public string Agent { get; set; } = "";
        public string GameName { get; set; } = "";

        public DateTime EntryDate { get; set; }
        public DateTime DrawDate { get; set; }
    }
}
