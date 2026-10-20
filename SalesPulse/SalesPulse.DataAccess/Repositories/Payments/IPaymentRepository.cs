using SalesPulse.Core.DTOs.PaymentDtos;

namespace SalesPulse.DataAccess.Repositories.Payments
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<ResultPaymentDto>> GetAllAsync();
        Task<UpdatePaymentDto> GetByIdAsync(int id);
        Task CreateAsync(CreatePaymentDto createPaymentDto);
        Task UpdateAsync(UpdatePaymentDto updatePaymentDto);
        Task DeleteAsync(int id);
    }
}
