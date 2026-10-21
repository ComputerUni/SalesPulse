using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.DashboardDtos
{
    public class DashboardCategoryPerformanceDto
    {
        public string CategoryName { get; set; }
        public decimal TotalRevenue { get; set; }
        public double Percentage { get; set; }
    }
}
