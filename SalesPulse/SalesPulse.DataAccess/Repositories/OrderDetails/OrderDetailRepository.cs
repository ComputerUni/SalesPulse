using Dapper;
using SalesPulse.Core.DTOs.OrderDetailDtos;
using SalesPulse.Core.DTOs.ProductDtos;
using SalesPulse.DataAccess.Context;

namespace SalesPulse.DataAccess.Repositories.OrderDetails
{
    public class OrderDetailRepository(AppDbContext _context) : IOrderDetailRepository
    {
        public async Task CreateAsync(CreateOrderDetailDto createOrderDetailDto)
        {
            string query = "INSERT INTO OrderDetails (OrderId, ProductId, Quantity, UnitPrice) VALUES (@OrderId, @ProductId, @Quantity, @UnitPrice)";
            var parameters = new DynamicParameters(createOrderDetailDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM OrderDetails WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultOrderDetailDto>> GetAllAsync()
        {
            string query = "SELECT * FROM OrderDetails od INNER JOIN Products p ON od.ProductId = p.Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultOrderDetailDto, ResultProductDto, ResultOrderDetailDto>(query, (orderDetail, product) =>
            {
                orderDetail.ProductName = product.Name;
                return orderDetail;
            }, splitOn: "ProductId");
        }

        public async Task<UpdateOrderDetailDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM OrderDetails WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UpdateOrderDetailDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateOrderDetailDto updateOrderDetailDto)
        {
            string query = "UPDATE OrderDetails SET OrderId = @OrderId, ProductId = @ProductId, Quantity = @Quantity, UnitPrice = @UnitPrice WHERE Id = @Id";
            var parameters = new DynamicParameters(updateOrderDetailDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
