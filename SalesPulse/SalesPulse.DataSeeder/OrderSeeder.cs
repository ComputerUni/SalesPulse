using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataSeeder
{
    public class OrderSeeder
    {
        public static async Task OrderSeederAsync(string connectionString)
        {
            var random = new Random();
            var statuses = new[] { "Teslim Edildi", "Beklemede", "İptal Edildi", "Kargoda", "İade Edildi" };
            var statusWeights = new[] { 50, 20, 10, 15, 5 }; 

            var table = new DataTable();
            table.Columns.Add("CustomerId", typeof(int));
            table.Columns.Add("CityId", typeof(int));
            table.Columns.Add("TotalAmount", typeof(decimal));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("CreatedAt", typeof(DateTime));

            for (int i = 0; i < 2000000; i++)
            {
                int customerId = random.Next(1, 100001);
                int cityId = random.Next(1, 82);

                if (random.Next(100) < 30)
                    cityId = new[] { 34, 35, 6, 7, 16, 41, 27, 38, 55, 42 }[random.Next(10)];

                decimal totalAmount = Math.Round((decimal)(random.Next(50, 50000) + random.NextDouble()), 2);

                int statusRoll = random.Next(100);
                string status;
                if (statusRoll < 50) status = "Teslim Edildi";
                else if (statusRoll < 70) status = "Beklemede";
                else if (statusRoll < 80) status = "İptal Edildi";
                else if (statusRoll < 95) status = "Kargoda";
                else status = "İade Edildi";


                DateTime createdAt = DateTime.Now.AddDays(-random.Next(1, 1095));

                int month = createdAt.Month;
                if (month == 11 || month == 12 || month == 1)
                    createdAt = DateTime.Now.AddDays(-random.Next(1, 365));
                else if (month == 6 || month == 7 || month == 8)
                    createdAt = DateTime.Now.AddDays(-random.Next(1, 365));

                table.Rows.Add(customerId, cityId, totalAmount, status, createdAt);

                if (i % 100000 == 0)
                    Console.WriteLine($"{i:N0} sipariş hazırlandı...");
            }

            Console.WriteLine("Veritabanına yazılıyor...");

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var bulkCopy = new SqlBulkCopy(connection);
            bulkCopy.DestinationTableName = "Orders";
            bulkCopy.BatchSize = 10000;
            bulkCopy.BulkCopyTimeout = 600;

            bulkCopy.ColumnMappings.Add("CustomerId", "CustomerId");
            bulkCopy.ColumnMappings.Add("CityId", "CityId");
            bulkCopy.ColumnMappings.Add("TotalAmount", "TotalAmount");
            bulkCopy.ColumnMappings.Add("Status", "Status");
            bulkCopy.ColumnMappings.Add("CreatedAt", "CreatedAt");

            await bulkCopy.WriteToServerAsync(table);

            Console.WriteLine("2.000.000 sipariş eklendi.");


        }
    }
}
