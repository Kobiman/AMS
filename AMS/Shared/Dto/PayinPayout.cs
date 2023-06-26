using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public record PayinPayout(
               string AgentId,
               string GameId,
               decimal PayinAmount,
               decimal PayoutAmount,
               decimal Amount,
               string Type,
               DateTime EntryDate
        );
}
