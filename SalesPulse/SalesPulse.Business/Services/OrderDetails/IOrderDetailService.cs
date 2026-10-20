using SalesPulse.Core.DTOs.CustomerDtos;
using SalesPulse.Core.DTOs.OrderDetailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.OrderDetails
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<ResultOrderDetailDto>> GetAllAsync();
        Task<UpdateOrderDetailDto> GetByIdAsync(int id);
        Task CreateAsync(CreateOrderDetailDto createOrderDetailDto);
        Task UpdateAsync(UpdateOrderDetailDto updateOrderDetailDto);
        Task DeleteAsync(int id);
    }
}
