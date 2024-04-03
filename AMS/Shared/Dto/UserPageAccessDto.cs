using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class UserPageAccessDto
    {
        public string PageValueName { get; set; }
        public string PageDisplayName { get; set; }
        public int RoleId { get; set; }
        public bool IsSelected { get; set; }
    }
}
