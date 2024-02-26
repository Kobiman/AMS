using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared
{
    public class Agent
    {
        public Agent()
        {
            AgentId = Guid.NewGuid().ToString();
            CreatedDate = DateTime.Now;
            Sales = new List<Sales>();
            Approved = false;
        }
        public string? AgentId { get; set; }
        public DateTime? CreatedDate { get; set; }

        [Required]
        public string? Name { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
        public string? HouseNo { get; set; }
        public string? Region { get; set; }

        [Required]
        public string? Phone { get; set; }
        //[Required]
        [Range(0.0, 100, ErrorMessage = "The field {0} value is not valid.")]
        public decimal Commission { get; set; }
        public string StaffId { get; set; } = String.Empty;
        public bool Approved { get; set; } = false;
        public string ApprovedBy { get; set; } = String.Empty;
        public int LocationId { get; set; }
        public IList<Sales> Sales { get; set; }
        public IList<Wins> Wins { get; set; }
    }
}
