using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class TransferDto
    {
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? SourceAccountId { get; set; }
        public string? SourceAccountType { get; set; } = string.Empty;
        public string? DestinationAccountId { get; set; }
        public string? DestinationAccountType { get; set; } = string.Empty;
        public string DestinationAccount { get; set; } = string.Empty;
        public string SourceAccount { get; set; } = string.Empty;
    }
}
