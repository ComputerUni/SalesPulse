using SalesPulse.Core.DTOs.CustomerDtos;
using SalesPulse.DataAccess.Repositories.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Customers
{
    public class CustomerService(ICustomerRepository _customerRepository) : ICustomerService
    {
        public async Task CreateAsync(CreateCustomerDto createCustomerDto)
        {
            await _customerRepository.CreateAsync(createCustomerDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResultCustomerDto>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<UpdateCustomerDto> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            await _customerRepository.UpdateAsync(updateCustomerDto);
        }
    }
}
