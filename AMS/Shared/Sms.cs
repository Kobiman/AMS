using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class Sms
    {
        [Required]
        public string msg { get; set; } = "";

        [Required]
        public string Phone { get; set; }

    }
}
