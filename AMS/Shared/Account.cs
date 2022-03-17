using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            CreatedDate = DateTime.Now;
        }
        public string? AccountId { get; set; }
        [Required]
        public string? AccountName { get; set; }
        [Required]
        public string? Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Balance { get; set; }
        public IList<AccountTransaction> Transactions { get; set; }
    }
}
