using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.SalesIntelligenceDtos
{
    public class SalesIntelligenceTopRevenueCustomerDto
    {
        public int Rank { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CityName { get; set; }
        public int OrderCount { get; set; }
        public decimal AverageOrderValue { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal RevenueSharePercentage { get; set; }
        public DateTime LastOrderDate { get; set; }
        public string SegmentLevel { get; set; }
    }
}
