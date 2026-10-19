using Dapper;
using SalesPulse.Core.DTOs.CategoryDtos;
using SalesPulse.Core.DTOs.ProductDtos;
using SalesPulse.DataAccess.Context;

namespace SalesPulse.DataAccess.Repositories.Products
{
    public class ProductRepository(AppDbContext _context) : IProductRepository
    {
        public async Task ChangeStatusAsync(int id)
        {
            var product = await GetByIdAsync(id);
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            if(product.IsActive)
            {
                parameters.Add("@IsActive", false);
            }
            else
            {
                parameters.Add("@IsActive", true);
            }

            string query = "UPDATE Products SET IsActive = @IsActive WHERE Id = @Id";
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task CreateAsync(CreateProductDto createProductDto)
        {
            string query = "INSERT INTO Products (Name, Stock, Price, CategoryId, IsActive) VALUES (@Name, @Stock, @Price, @CategoryId, @IsActive)";
            var parameters = new DynamicParameters(createProductDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Products p INNER JOIN Categories c ON p.CategoryId = c.Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultProductDto, ResultCategoryDto, ResultProductDto>(query, (product, category) =>
            {
                product.CategoryName = category.Name;
                return product;
            }, splitOn: "CategoryId");
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Products WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UpdateProductDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            string query = "UPDATE Products SET Name = @Name, Stock = @Stock, Price = @Price, CategoryId = @CategoryId, IsActive = @IsActive WHERE Id = @Id";
            var parameters = new DynamicParameters(updateProductDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
