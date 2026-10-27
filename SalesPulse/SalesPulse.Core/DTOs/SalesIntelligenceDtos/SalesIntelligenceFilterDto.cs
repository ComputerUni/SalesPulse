using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.SalesIntelligenceDtos
{
    public class SalesIntelligenceFilterDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
