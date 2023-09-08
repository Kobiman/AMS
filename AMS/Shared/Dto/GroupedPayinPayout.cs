using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
  public record GroupedPayinPayout(string AgentId, decimal DailySales, decimal WinAmount, List<SalesDetails> Details);
}
