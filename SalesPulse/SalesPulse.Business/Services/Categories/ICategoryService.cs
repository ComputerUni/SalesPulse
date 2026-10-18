using SalesPulse.Core.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllAsync();
    }
}
