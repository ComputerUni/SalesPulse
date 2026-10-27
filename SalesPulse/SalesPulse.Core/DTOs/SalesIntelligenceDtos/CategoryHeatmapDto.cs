using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.SalesIntelligenceDtos
{
    public class CategoryHeatmapDto
    {
        public List<MonthHeaderDto> Months { get; set; } = new();
        public List<CategoryHeatmapRowDto> Rows { get; set; } = new();
        public decimal MaxRevenue { get; set; }
    }

    public class MonthHeaderDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
    }

    public class CategoryHeatmapRowDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Dictionary<string, decimal> MonthlyRevenues { get; set; } = new();
        public decimal TotalPeriodRevenue { get; set; }
    }
}
