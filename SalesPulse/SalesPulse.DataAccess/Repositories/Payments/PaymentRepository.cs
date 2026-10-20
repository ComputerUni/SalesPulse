using Dapper;
using SalesPulse.Core.DTOs.OrderDetailDtos;
using SalesPulse.Core.DTOs.OrderDtos;
using SalesPulse.Core.DTOs.PaymentDtos;
using SalesPulse.Core.DTOs.ProductDtos;
using SalesPulse.DataAccess.Context;

namespace SalesPulse.DataAccess.Repositories.Payments
{
    public class PaymentRepository(AppDbContext _context) : IPaymentRepository
    {
        public async Task CreateAsync(CreatePaymentDto createPaymentDto)
        {
            string query = "INSERT INTO Payments (OrderId, PaymentMethod, PaidAt) VALUES (@OrderId, @PaymentMethod, GETDATE())";
            var parameters = new DynamicParameters(createPaymentDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Payments WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultPaymentDto>> GetAllAsync()
        {
            string query = "SELECT Id, OrderId, PaymentMethod, PaidAt FROM Payments";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultPaymentDto>(query);
        }

        public async Task<UpdatePaymentDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Payments WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UpdatePaymentDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdatePaymentDto updatePaymentDto)
        {
            string query = "UPDATE Payments SET OrderId = @OrderId, PaymentMethod = @PaymentMethod WHERE Id = @Id";
            var parameters = new DynamicParameters(updatePaymentDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
