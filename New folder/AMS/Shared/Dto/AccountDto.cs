using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public record AccountDto(string? AccountName,string? AccountId,string? Type,decimal Balance,DateTime CreatedDate);
}
