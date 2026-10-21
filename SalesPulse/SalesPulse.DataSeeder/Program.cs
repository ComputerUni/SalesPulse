using SalesPulse.DataSeeder;

string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=SalesPulseDb;Integrated Security=True;Trust Server Certificate=True;";
//await ProductSeeder.ProductSeederAsync(connectionString);
//await CustomerSeeder.CustomerSeederAsync(connectionString);
//await OrderSeeder.OrderSeederAsync(connectionString);
//await OrderDetailSeeder.OrderDetailSeederAsync(connectionString);
//await UpdateTotalAmountsSeeder.UpdateTotalAmountsAsync(connectionString);
await PaymentSeeder.PaymentSeederAsync(connectionString);