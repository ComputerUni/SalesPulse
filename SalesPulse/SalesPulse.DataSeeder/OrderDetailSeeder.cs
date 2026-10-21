using Microsoft.Data.SqlClient;
using System.Data;

namespace SalesPulse.DataSeeder
{
    public class OrderDetailSeeder
    {
        public static async Task OrderDetailSeederAsync(string connectionString)
        {
            var random = new Random(42);

            var products = new List<(int Id, decimal Price)>();
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand(
                    "SELECT Id, Price FROM Products WHERE IsActive = 1", conn);
                using var reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                    products.Add((reader.GetInt32(0), reader.GetDecimal(1)));
            }

            Console.WriteLine($"{products.Count} ürün yüklendi.");

            int totalOrders;
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Orders", conn);
                totalOrders = (int)await cmd.ExecuteScalarAsync();
            }

            Console.WriteLine($"{totalOrders:N0} sipariş için detay üretiliyor...");


            const int batchSize = 50_000;

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            var table = BuildDataTable();

            for (int start = 1; start <= totalOrders; start += batchSize)
            {
                int end = Math.Min(start + batchSize - 1, totalOrders);
                table.Clear();

                for (int orderId = start; orderId <= end; orderId++)
                {
                    int itemCount = random.Next(1, 6);
                    var usedIndexes = new HashSet<int>();

                    for (int j = 0; j < itemCount; j++)
                    {
                        int idx;
                        do { idx = random.Next(products.Count); }
                        while (!usedIndexes.Add(idx)); 

                        int productId = products[idx].Id;
                        decimal unitPrice = products[idx].Price;
                        int quantity = random.Next(1, 6); 

                        table.Rows.Add(orderId, productId, quantity, unitPrice);
                    }
                }

                using var bulk = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "OrderDetails",
                    BatchSize = 10_000,
                    BulkCopyTimeout = 600
                };
                bulk.ColumnMappings.Add("OrderId", "OrderId");
                bulk.ColumnMappings.Add("ProductId", "ProductId");
                bulk.ColumnMappings.Add("Quantity", "Quantity");
                bulk.ColumnMappings.Add("UnitPrice", "UnitPrice");

                await bulk.WriteToServerAsync(table);

                Console.WriteLine($"  {end:N0} / {totalOrders:N0} detay eklendi.");
            }

     
            Console.WriteLine("Orders.TotalAmount güncelleniyor...");
            using (var cmd = new SqlCommand(@"
                UPDATE o
                SET    o.TotalAmount = od.Total
                FROM   Orders o
                JOIN   (
                    SELECT   OrderId,
                             SUM(CAST(Quantity AS decimal(18,2)) * UnitPrice) AS Total
                    FROM     OrderDetails
                    GROUP BY OrderId
                ) od ON od.OrderId = o.Id;
            ", connection) { CommandTimeout = 600 })
            {
                await cmd.ExecuteNonQueryAsync();
            }

            Console.WriteLine("Tamamlandı. TotalAmount değerleri güncellendi.");
        }

        private static DataTable BuildDataTable()
        {
            var dt = new DataTable();
            dt.Columns.Add("OrderId", typeof(int));
            dt.Columns.Add("ProductId", typeof(int));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("UnitPrice", typeof(decimal));
            return dt;
        }
    }
}

