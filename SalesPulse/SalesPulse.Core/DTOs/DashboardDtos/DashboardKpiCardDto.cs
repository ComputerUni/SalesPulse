using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.DashboardDtos
{
    public class DashboardKpiCardDto
    {
        public int TotalOrder { get; set; }
        public decimal TotalRevenue { get; set; }
        public int TotalCustomer { get; set; }
        public decimal AverageBasket { get; set; }
    }
}
