using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.OrderExplorerDtos
{
    public class OrderExplorerKpiDto
    {
        public int TotalCount { get; set; }
        public decimal TotalAmount { get; set; }
        public int DeliveredCount { get; set; }
        public decimal AverageOrderAmount => TotalCount > 0 ? Math.Round(TotalAmount / TotalCount, 2) : 0;
        public decimal DeliverySuccessRate => TotalCount > 0 ? Math.Round(((decimal)DeliveredCount / TotalCount) * 100, 1) : 0;
    }
}
