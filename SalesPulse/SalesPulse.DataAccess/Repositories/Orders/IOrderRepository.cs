using SalesPulse.Core.DTOs.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<IEnumerable<ResultOrderDto>> GetAllAsync();
        Task<UpdateOrderDto> GetByIdAsync(int id);
        Task CreateAsync(CreateOrderDto createOrderDto);
        Task UpdateAsync(UpdateOrderDto updateOrderDto);
        Task DeleteAsync(int id);
        Task ChangeStatusAsync(int id, string status);

    }
}
