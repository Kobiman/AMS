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
        public string? DestinationAccountId { get; set; }
        public string DestinationAccount { get; set; }
        public string SourceAccount { get; set; }
    }
}
