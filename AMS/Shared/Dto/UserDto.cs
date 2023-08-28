using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string StaffId { get; set; } = String.Empty;

        public int LocationId { get; set; }
        public string Role { get; set; }
    }
}
