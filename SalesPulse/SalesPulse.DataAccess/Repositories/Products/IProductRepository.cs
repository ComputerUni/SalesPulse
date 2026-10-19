using SalesPulse.Core.DTOs.ProductDtos;

namespace SalesPulse.DataAccess.Repositories.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<ResultProductDto>> GetAllAsync();
        Task<UpdateProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto createProductDto);
        Task UpdateAsync(UpdateProductDto updateProductDto);
        Task DeleteAsync(int id);
        Task ChangeStatusAsync(int id);
    }
}
