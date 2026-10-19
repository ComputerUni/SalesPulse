using SalesPulse.Core.DTOs.CustomerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<ResultCustomerDto>> GetAllAsync();
        Task<UpdateCustomerDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCustomerDto createCustomerDto);
        Task UpdateAsync(UpdateCustomerDto updateCustomerDto);
        Task DeleteAsync(int id);
    }
}
