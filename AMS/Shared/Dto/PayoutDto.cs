using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class PayoutDto
    {
        public string Id { get; set; } 
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? AgentId { get; set; }
        //public string? GameId { get; set; }
        public string? SourceAccountId { get; set; }
        public string? DestinationAccountId { get; set; }
        public string DestinationAccount { get; set; }
        public string SourceAccount { get; set; }
        public string Agent { get; set; } = "";
        //public string GameName { get; set; } = "";
        public string? Type { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Approved { get; set; } = false;
        public string StaffId { get; set; } = String.Empty;
        public string ApprovedBy { get; set; } = String.Empty;
        public string AreaOfOperations { get; set; } = string.Empty;
        public string ChequeNo { get; set; } = string.Empty;
        public string TreatedBy { get; set; } = string.Empty;
        public string ReceivedBy { get; set; } = string.Empty;
        public string ReceivedFrom { get; set; } = string.Empty;
        public string ReceiverPhone { get; set; } = string.Empty;
    }
}
