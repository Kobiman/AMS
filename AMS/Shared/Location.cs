using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string LocationName { get; set; }

        public string LocationABV { get; set; }
    }
}
