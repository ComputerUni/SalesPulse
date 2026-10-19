using SalesPulse.Core.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<ResultCustomerDto>> GetAllAsync();
        Task<UpdateCustomerDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCustomerDto createCustomerDto);
        Task UpdateAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteAsync(int id);
    }
}
