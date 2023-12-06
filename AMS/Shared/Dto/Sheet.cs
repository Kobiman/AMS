using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class Sheet 
    {
        public string SheetNo { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string TreatedBy { get; set; } = string.Empty;
        public string ApprovedBy { get; set; } = string.Empty;
    }
}
