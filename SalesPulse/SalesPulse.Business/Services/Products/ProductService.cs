using SalesPulse.Core.DTOs.ProductDtos;
using SalesPulse.DataAccess.Repositories.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Products
{
    public class ProductService(IProductRepository _productRepository) : IProductService
    {
        public Task ChangeStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public Task<UpdateProductDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
