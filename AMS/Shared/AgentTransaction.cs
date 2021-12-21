using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class AgentTransaction
    {
        public AgentTransaction()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public string AgentId { get; set; }
        public Agent Agent { get; set; }
    }
}
