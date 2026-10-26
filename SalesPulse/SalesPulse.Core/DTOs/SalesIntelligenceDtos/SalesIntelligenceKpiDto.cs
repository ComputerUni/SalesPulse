using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.SalesIntelligenceDtos
{
    public class SalesIntelligenceKpiDto
    {
        public decimal RepeatPurchaseRate { get; set; }
        public decimal CustomerLifetimeValue { get; set; }
        public decimal AverageOrderValue { get; set; }
        public int AverageOrderCycleDays { get; set; }
    }
}
