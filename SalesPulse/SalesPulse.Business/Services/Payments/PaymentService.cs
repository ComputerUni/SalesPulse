using SalesPulse.Core.DTOs.PaymentDtos;
using SalesPulse.DataAccess.Repositories.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Payments
{
    public class PaymentService(IPaymentRepository _paymentRepository) : IPaymentService
    {
        public async Task CreateAsync(CreatePaymentDto createPaymentDto)
        {
            await _paymentRepository.CreateAsync(createPaymentDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResultPaymentDto>> GetAllAsync()
        {
            return await _paymentRepository.GetAllAsync();
        }

        public async Task<UpdatePaymentDto> GetByIdAsync(int id)
        {
            return await _paymentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdatePaymentDto updatePaymentDto)
        {
            await _paymentRepository.UpdateAsync(updatePaymentDto);
        }
    }
}
