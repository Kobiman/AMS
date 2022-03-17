using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Transfer
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public string? SourceAccountId { get; set; }
        public string? DestinationAccountId { get; set; }
    }
}
