using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.SalesIntelligenceDtos
{
    public class TopCitySalesDto
    {
        public string CityName { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; }
        public decimal GrowthRate { get; set; }
        public decimal PercentageOfMax { get; set; }
    }
}
