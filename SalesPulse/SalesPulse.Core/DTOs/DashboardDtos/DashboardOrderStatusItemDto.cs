using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.DashboardDtos
{
    public class DashboardOrderStatusItemDto
    {
        public string Status { get; set; }
        public int OrderCount { get; set; }
        public double Percentage { get; set; }
    }
}
