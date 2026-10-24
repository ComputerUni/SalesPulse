using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.OrderExplorerDtos
{
    public class OrderExplorerFilterDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public string? SearchTerm { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? CityId { get; set; }
        public string? Status { get; set; }
        public string? PaymentMethod { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }
}
