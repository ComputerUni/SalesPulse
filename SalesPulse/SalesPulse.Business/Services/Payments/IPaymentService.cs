using SalesPulse.Core.DTOs.CustomerDtos;
using SalesPulse.Core.DTOs.PaymentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Payments
{
    public interface IPaymentService
    {
        Task<IEnumerable<ResultPaymentDto>> GetAllAsync();
        Task<UpdatePaymentDto> GetByIdAsync(int id);
        Task CreateAsync(CreatePaymentDto createPaymentDto);
        Task UpdateAsync(UpdatePaymentDto updatePaymentDto);
        Task DeleteAsync(int id);
    }
}
