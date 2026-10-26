using SalesPulse.Business.Services.Categories;
using SalesPulse.Business.Services.Cities;
using SalesPulse.Business.Services.Customers;
using SalesPulse.Business.Services.Dashboards;
using SalesPulse.Business.Services.OrderDetails;
using SalesPulse.Business.Services.OrderExplorers;
using SalesPulse.Business.Services.Orders;
using SalesPulse.Business.Services.Payments;
using SalesPulse.Business.Services.Products;
using SalesPulse.Business.Services.SalesIntelligence;
using SalesPulse.DataAccess.Context;
using SalesPulse.DataAccess.Repositories.Categories;
using SalesPulse.DataAccess.Repositories.Cities;
using SalesPulse.DataAccess.Repositories.Customers;
using SalesPulse.DataAccess.Repositories.Dashboards;
using SalesPulse.DataAccess.Repositories.OrderDetails;
using SalesPulse.DataAccess.Repositories.OrderExplorers;
using SalesPulse.DataAccess.Repositories.Orders;
using SalesPulse.DataAccess.Repositories.Payments;
using SalesPulse.DataAccess.Repositories.Products;
using SalesPulse.DataAccess.Repositories.SalesIntelligence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddScoped<AppDbContext>(_ => new AppDbContext(connectionString));

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddScoped<IOrderExplorerRepository, OrderExplorerRepository>();
builder.Services.AddScoped<IOrderExplorerService, OrderExplorerService>();

builder.Services.AddScoped<ISalesIntelligenceRepository, SalesIntelligenceRepository>();
builder.Services.AddScoped<ISalesIntelligenceService, SalesIntelligenceService>();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
