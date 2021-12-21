using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Account
    {
        public Account()
        {
            AccountId = Guid.NewGuid().ToString();
            Transactions = new List<AccountTransaction>();
        }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        public IList<AccountTransaction> Transactions { get; set; }
    }
}
