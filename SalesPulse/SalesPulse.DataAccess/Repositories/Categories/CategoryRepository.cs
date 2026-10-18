using Dapper;
using SalesPulse.Core.DTOs.CategoryDtos;
using SalesPulse.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.Categories
{
    public class CategoryRepository(AppDbContext _context) : ICategoryRepository
    {
        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            string query = "SELECT NAME FROM Categories";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultCategoryDto>(query);
        }
    }
}
