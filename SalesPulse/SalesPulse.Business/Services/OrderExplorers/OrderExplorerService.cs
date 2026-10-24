using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.OrderExplorerDtos;
using SalesPulse.DataAccess.Repositories.OrderExplorers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.OrderExplorers
{
    public class OrderExplorerService(IOrderExplorerRepository _orderExplorerRepository) : IOrderExplorerService
    {
        public async Task<PagedResult<OrderExplorerListItemDto>> OrderExplorerListItemAsync(OrderExplorerFilterDto filter)
        {
            return await _orderExplorerRepository.OrderExplorerListItemAsync(filter);
        }
    }
}
