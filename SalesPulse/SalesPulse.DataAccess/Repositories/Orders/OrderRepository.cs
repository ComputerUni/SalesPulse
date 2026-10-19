using Dapper;
using SalesPulse.Core.DTOs.CityDtos;
using SalesPulse.Core.DTOs.CustomerDtos;
using SalesPulse.Core.DTOs.OrderDtos;
using SalesPulse.DataAccess.Context;

namespace SalesPulse.DataAccess.Repositories.Orders
{
    public class OrderRepository(AppDbContext _context) : IOrderRepository
    {
        public async Task ChangeStatusAsync(int id, string status)
        {
            string query = "UPDATE Orders SET Status = @Status WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            parameters.Add("@Status", status);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task CreateAsync(CreateOrderDto createOrderDto)
        {
            string query = "INSERT INTO Orders (CityId, TotalAmount, Status, CreatedAt) VALUES (@CityId, @TotalAmount, @Status, GETDATE())";
            var parameters = new DynamicParameters(createOrderDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Orders WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultOrderDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Orders o INNER JOIN Customers c ON o.CustomerId = c.Id INNER JOIN Cities ct ON o.CityId = ct.Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultOrderDto, ResultCustomerDto, ResultCityDto, ResultOrderDto>(query, (order, customer, city) =>
            {
                order.CustomerName = customer.FirstName + " " + customer.LastName;
                order.CityName = city.Name;
                return order;
            }, splitOn: "CustomerId,CityId");
        }

        public async Task<UpdateOrderDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Orders Where Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UpdateOrderDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateOrderDto updateOrderDto)
        {
            string query = "UPDATE Orders SET CustomerId = @CustomerId, CityId = @CityId, TotalAmount = @TotalAmount, Status = @Status WHERE Id = @Id";
            var parameters = new DynamicParameters(updateOrderDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
