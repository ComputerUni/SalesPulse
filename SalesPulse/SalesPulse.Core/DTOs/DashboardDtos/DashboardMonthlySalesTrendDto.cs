using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.DashboardDtos
{
    public class DashboardMonthlySalesTrendDto
    {
        public List<DashboardMonthlySalesItemDto> MonthlyItems { get; set; }
        public string PeakMonth { get; set; }
        public decimal PeakRevenue { get; set; }
        public decimal AverageMonthlyRevenue { get; set; }
        public double TargetAchievementRate { get; set; }
    }
}
