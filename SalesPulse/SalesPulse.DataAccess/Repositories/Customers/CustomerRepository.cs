using Dapper;
using SalesPulse.Core.DTOs.CityDtos;
using SalesPulse.Core.DTOs.CustomerDtos;
using SalesPulse.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.Customers
{
    public class CustomerRepository(AppDbContext _context) : ICustomerRepository
    {
        public async Task CreateAsync(CreateCustomerDto createCustomerDto)
        {
            string query = "INSERT INTO Customers (FirstName, LastName, Email, Username, ImageUrl, CityId, CreatedAt) VALUES (@FirstName, @LastName, @Email, @Username, @ImageUrl, @CityId, GETDATE())";
            var parameters = new DynamicParameters(createCustomerDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "DELETE FROM Customers WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCustomerDto>> GetAllAsync()
        {
            string query = "SELECT * FROM Customers c INNER JOIN Cities ct ON c.CityId = ct.Id";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultCustomerDto, ResultCityDto, ResultCustomerDto>(query, (customer, city) =>
            {
                customer.CityName = city.Name;
                return customer;
            }, splitOn: "CityId");
        }

        public async Task<UpdateCustomerDto> GetByIdAsync(int id)
        {
            string query = "SELECT * FROM Customers WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UpdateCustomerDto>(query, parameters);
        }

        public async Task UpdateAsync(UpdateCustomerDto updateCustomerDto)
        {
            string query = "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Username = @Username, ImageUrl = @ImageUrl, CityId = @CityId WHERE Id = @Id";
            var parameters = new DynamicParameters(updateCustomerDto);
            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
