using Dapper;
using SalesPulse.Core.DTOs.CityDtos;
using SalesPulse.DataAccess.Context;
using System.Data;


namespace SalesPulse.DataAccess.Repositories.Cities
{
    public class CityRepository(AppDbContext _context) : ICityRepository
    {
        public async Task<IEnumerable<ResultCityDto>> GetAllAsync()
        {
            string query = "SELECT NAME FROM Cities";
            var connection = _context.CreateConnection();
            return await connection.QueryAsync<ResultCityDto>(query);
        }
    }
}
