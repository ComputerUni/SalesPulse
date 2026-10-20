using SalesPulse.DataSeeder;

string connectionString = "Data Source=;Initial Catalog=SalesPulseDb;Integrated Security=True;Trust Server Certificate=True;";

//await ProductSeeder.ProductSeederAsync(connectionString);
//await CustomerSeeder.CustomerSeederAsync(connectionString);
await OrderSeeder.OrderSeederAsync(connectionString);
