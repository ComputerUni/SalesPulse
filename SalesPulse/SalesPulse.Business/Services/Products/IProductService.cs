using SalesPulse.Core.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ResultProductDto>> GetAllAsync();
        Task<UpdateProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(int id);
        Task ChangeStatusAsync(int id);
    }
}
