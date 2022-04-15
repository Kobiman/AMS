using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public record TrialBalanceDto(string? AccountName, string AccountType, string Code, decimal Debit, decimal Credit);
}
