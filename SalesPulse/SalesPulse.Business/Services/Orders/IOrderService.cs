using SalesPulse.Core.DTOs.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Orders
{
    public interface IOrderService
    {
        Task<IEnumerable<ResultOrderDto>> GetAllAsync();
        Task<UpdateOrderDto> GetByIdAsync(int id);
        Task CreateAsync(CreateOrderDto createOrderDto);
        Task UpdateAsync(UpdateOrderDto updateOrderDto);
        Task DeleteAsync(int id);
        Task ChangeStatusAsync(int id, string status);
    }
}
