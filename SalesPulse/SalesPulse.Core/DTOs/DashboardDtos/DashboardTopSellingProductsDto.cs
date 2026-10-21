using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.DashboardDtos
{
    public class DashboardTopSellingProductsDto
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public int SalesVolume { get; set; }
        public decimal Price { get; set; }
        public decimal TotalRevenue { get; set; }
        public int Stock { get; set; }
    }
}
