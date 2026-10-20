using SalesPulse.Core.DTOs.OrderDetailDtos;
using SalesPulse.DataAccess.Repositories.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.OrderDetails
{
    public class OrderDetailService(IOrderDetailRepository _orderDetailRepository) : IOrderDetailService
    {
        public async Task CreateAsync(CreateOrderDetailDto createOrderDetailDto)
        {
            await _orderDetailRepository.CreateAsync(createOrderDetailDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderDetailRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResultOrderDetailDto>> GetAllAsync()
        {
            return await _orderDetailRepository.GetAllAsync();
        }

        public async Task<UpdateOrderDetailDto> GetByIdAsync(int id)
        {
            return await _orderDetailRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateOrderDetailDto updateOrderDetailDto)
        {
            await _orderDetailRepository.UpdateAsync(updateOrderDetailDto);
        }
    }
}
