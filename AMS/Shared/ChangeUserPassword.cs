using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class ChangeUserPassword
    {
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage ="The passwords do not match")]
        public string ConfirmPassword{ get; set; } =  string.Empty;
    }
}
