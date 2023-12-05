using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class AgentGameCommission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AgentId { get; set; }

        [Required]
        public string GameId { get; set; }
        public decimal Commission { get; set; }
    }
}
