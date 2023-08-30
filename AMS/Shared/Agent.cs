using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Agent
    {
        public Agent()
        {
            AgentId = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            Transactions = new List<Sales>();
            Approved = false;
        }
        public string? AgentId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? HouseNo { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }
        public string StaffId { get; set; } = String.Empty;
        public bool Approved { get; set; } = false;
        public string ApprovedBy { get; set; } = String.Empty;
        public int LocationId { get; set; }
        public IList<Sales> Transactions { get; set; }
    }
}
