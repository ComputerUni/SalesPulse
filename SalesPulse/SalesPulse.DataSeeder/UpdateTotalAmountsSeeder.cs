using Microsoft.Data.SqlClient;

namespace SalesPulse.DataSeeder
{
    public class UpdateTotalAmountsSeeder
    {
        public static async Task UpdateTotalAmountsAsync(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            Console.WriteLine("Orders.TotalAmount güncelleniyor...");

            const int updateBatch = 100_000;
            int updated = 0;
            int offset = 0;

            while (true)
            {
                using var cmd = new SqlCommand(@"
            UPDATE o
            SET    o.TotalAmount = od.Total
            FROM   Orders o
            JOIN   (
                SELECT   OrderId,
                         SUM(CAST(Quantity AS decimal(18,2)) * UnitPrice) AS Total
                FROM     OrderDetails
                GROUP BY OrderId
            ) od ON od.OrderId = o.Id
            WHERE o.Id BETWEEN @start AND @end
        ", connection) { CommandTimeout = 600 };

                cmd.Parameters.AddWithValue("@start", offset + 1);
                cmd.Parameters.AddWithValue("@end", offset + updateBatch);

                int rows = await cmd.ExecuteNonQueryAsync();
                updated += rows;
                offset += updateBatch;

                Console.WriteLine($"  {updated:N0} / 2.000.000 güncellendi.");

                if (offset >= 2_000_000) break;
            }

            Console.WriteLine("Tamamlandı!");
        }
    }
}
