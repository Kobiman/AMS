using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AddPayoutDto
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? AgentId { get; set; }
        [Required]
        public string? GameId { get; set; }

        [Required]
        public string? SourceAccountId { get; set; }
        [Required]
        public string? DestinationAccountId { get; set; }
        public string SourceAccountType { get; set; }
        public string DestinationAccountType { get; set; }
    }
}
