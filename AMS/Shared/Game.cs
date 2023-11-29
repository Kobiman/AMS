using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Game
    {
        public Game()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string? Id { get; set; }
        public string Name { get; set; }
        public int? Srl { get; set; }

        [Required]
        [Range(0.0, 100, ErrorMessage = "The Commission value is not valid.")]
        public decimal Commission { get; set; } = 0;
    }
}
