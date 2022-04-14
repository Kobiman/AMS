using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AddTransactionDto
    {
        public string? AccountId { get; set; }
        [Required]
        public string? Description { get; set; }
        public string? AccountType { get; set; }
        [Required]
        public string? Operation { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}
