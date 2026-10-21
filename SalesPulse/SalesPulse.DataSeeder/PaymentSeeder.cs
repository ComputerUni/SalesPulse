using Microsoft.Data.SqlClient;

namespace SalesPulse.DataSeeder
{
    public class PaymentSeeder
    {
        private static readonly string[] PaymentMethods = ["Kredi Kartı", "Banka Kartı", "Havale EFT", "Nakit", "Kapıda Ödeme"];

        public static async Task PaymentSeederAsync(string connectionString)
        {
            var random = new Random(42);

            int totalOrders;
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Orders", conn);
                totalOrders = (int)await cmd.ExecuteScalarAsync();
            }

            Console.WriteLine($"{totalOrders:N0} sipariş için ödeme kaydı üretiliyor...");

            const int batchSize = 50_000;

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            for (int start = 1; start <= totalOrders; start += batchSize)
            {
                int end = Math.Min(start + batchSize - 1, totalOrders);

                var table = new System.Data.DataTable();
                table.Columns.Add("OrderId", typeof(int));
                table.Columns.Add("PaymentMethod", typeof(string));
                table.Columns.Add("PaidAt", typeof(DateTime));

                for (int orderId = start; orderId <= end; orderId++)
                {
                    string method = PaymentMethods[random.Next(PaymentMethods.Length)];
                    DateTime paidAt = DateTime.Now.AddDays(-random.Next(1, 365));

                    table.Rows.Add(orderId, method, paidAt);
                }

                using var bulk = new SqlBulkCopy(connection)
                {
                    DestinationTableName = "Payments",
                    BatchSize = 10_000,
                    BulkCopyTimeout = 600
                };
                bulk.ColumnMappings.Add("OrderId", "OrderId");
                bulk.ColumnMappings.Add("PaymentMethod", "PaymentMethod");
                bulk.ColumnMappings.Add("PaidAt", "PaidAt");

                await bulk.WriteToServerAsync(table);

                Console.WriteLine($"  {end:N0} / {totalOrders:N0} ödeme eklendi.");
            }

            Console.WriteLine("Tamamlandı! Tüm ödeme kayıtları eklendi.");
        }
    }
}
