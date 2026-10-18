using Microsoft.Data.SqlClient;
using System.Data;


namespace SalesPulse.DataAccess.Context
{
    public class AppDbContext
    {
        private readonly string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
