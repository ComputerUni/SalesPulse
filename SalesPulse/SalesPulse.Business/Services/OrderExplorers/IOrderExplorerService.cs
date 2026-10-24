using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.OrderExplorerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.OrderExplorers
{
    public interface IOrderExplorerService
    {
        Task<PagedResult<OrderExplorerListItemDto>> OrderExplorerListItemAsync(OrderExplorerFilterDto filter);
        Task<OrderExplorerDetailItemDto> GetOrderDetailItemAsync(string orderCode);
    }
}
