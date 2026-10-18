using SalesPulse.Core.DTOs.CategoryDtos;
using SalesPulse.DataAccess.Repositories.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Categories
{
    public class CategoryService(ICategoryRepository _categoryRepository) : ICategoryService
    {
        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }
    }
}
