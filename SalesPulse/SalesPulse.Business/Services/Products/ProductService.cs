using SalesPulse.Core.DTOs.ProductDtos;
using SalesPulse.DataAccess.Repositories.Products;

namespace SalesPulse.Business.Services.Products
{
    public class ProductService(IProductRepository _productRepository) : IProductService
    {
        public async Task ChangeStatusAsync(int id)
        {
            await _productRepository.ChangeStatusAsync(id);
        }

        public async Task CreateAsync(CreateProductDto createProductDto)
        {
            await _productRepository.CreateAsync(createProductDto);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            await _productRepository.UpdateAsync(updateProductDto);
        }
    }
}
