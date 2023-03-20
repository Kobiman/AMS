﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Shared.Dto
{
    public class AgentReportDto
    {
        public DateTime? CreatedDate { get; set; }
        public string? AgentId { get; set; }
        public string? Name { get; set; }
        public string? Game { get; set; }
        public decimal Sales { get; set; }
        public decimal Payin { get; set; }
        public decimal Payout { get; set; }
        public decimal Balance { get; set; }
    }
}