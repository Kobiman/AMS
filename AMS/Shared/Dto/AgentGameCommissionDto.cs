using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AgentGameCommissionDto
    {
        public int Id { get; set; }

        public string AgentId { get; set; }

        public string Agent { get; set; }

        public string GameId { get; set; } = String.Empty;
        public string Game { get; set; } = String.Empty;

        [Range(0.0, 100, ErrorMessage = "The Commission value is not valid.")]
        public decimal Commission { get; set; }
    }
}
