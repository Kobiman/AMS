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
    }
}
