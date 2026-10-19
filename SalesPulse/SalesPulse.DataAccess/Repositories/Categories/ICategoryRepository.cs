using SalesPulse.Core.DTOs.CategoryDtos;

namespace SalesPulse.DataAccess.Repositories.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllAsync();
    }
}
