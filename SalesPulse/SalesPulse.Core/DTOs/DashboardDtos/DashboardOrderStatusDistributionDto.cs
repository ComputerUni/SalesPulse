using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.DashboardDtos
{
    public class DashboardOrderStatusDistributionDto
    {
        public List<DashboardOrderStatusItemDto> Items { get; set; }
        public int TotalOrderCount { get; set; }
    }
}
