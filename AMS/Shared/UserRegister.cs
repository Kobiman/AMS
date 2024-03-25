using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(maximumLength:80, MinimumLength =6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password",ErrorMessage ="The passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
        //public string Role { get; set; } = string.Empty;
        public int? LocationId { get; set; } = null;

        [Required]
        public string StaffId { get; set; }
    }
}
