using SalesPulse.Core.DTOs.OrderDtos;
using SalesPulse.DataAccess.Repositories.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Orders
{
    public class OrderService(IOrderRepository _orderRepository) : IOrderService
    {
        public async Task ChangeStatusAsync(int id, string status)
        {
            await _orderRepository.ChangeStatusAsync(id, status);
        }

        public async Task CreateAsync(CreateOrderDto createOrderDto)
        {
            await _orderRepository.CreateAsync(createOrderDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResultOrderDto>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<UpdateOrderDto> GetByIdAsync(int id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateOrderDto updateOrderDto)
        {
            await _orderRepository.UpdateAsync(updateOrderDto);
        }
    }
}
