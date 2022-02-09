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
            Transactions = new List<AgentTransaction>();
        }
        public string? AgentId { get; set; }
        public string? Name { get; set; }
        public string? Region { get; set; }
        public string? Contact { get; set; }
        public IList<AgentTransaction> Transactions { get; set; }
    }
}
