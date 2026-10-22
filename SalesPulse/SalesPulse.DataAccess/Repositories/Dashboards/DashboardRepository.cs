using Dapper;
using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.DashboardDtos;
using SalesPulse.DataAccess.Context;
using System.Data;


namespace SalesPulse.DataAccess.Repositories.Dashboards
{
    public class DashboardRepository(AppDbContext _context) : IDashboardRepository
    {
        public async Task<IEnumerable<DashboardCategoryPerformanceDto>> CategoryPerformanceAsync()
        {
            string query = "SELECT TOP 10 c.Name AS CategoryName, SUM(od.Quantity * od.UnitPrice) AS TotalRevenue FROM OrderDetails od INNER JOIN Products p ON od.ProductId = p.Id INNER JOIN Categories c ON p.CategoryId = c.Id GROUP BY c.Id, c.Name ORDER BY TotalRevenue DESC";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<DashboardCategoryPerformanceDto>(query);
            var list = result.ToList();
            decimal total = list.Sum(x => x.TotalRevenue);
            if(total > 0)
            {
                foreach(var item in list)
                {
                    item.Percentage = Math.Round((double)(item.TotalRevenue / total * 100), 1);
                }
            }
            return list;

        }

        public async Task<DashboardKpiCardDto> KpiCardsAsync()
        {
            string query = "SELECT COUNT(*) AS TotalOrder, SUM(TotalAmount) AS TotalRevenue, (SELECT COUNT(*) FROM Customers) AS TotalCustomer, AVG(TotalAmount) AS AverageBasket FROM Orders";
            using var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<DashboardKpiCardDto>(query);
        }

        public async Task<IEnumerable<DashboardRegionalDistributionDto>> RegionalDistributionAsync()
        {
            string query = "SELECT TOP 10 c.Name AS CityName, SUM(o.TotalAmount) AS TotalRevenue, COUNT(o.Id) AS TotalOrder FROM Orders o INNER JOIN Cities c ON o.CityId = c.Id GROUP BY c.Id, c.Name ORDER BY TotalRevenue DESC";
            using var connection = _context.CreateConnection();
            var result = await connection.QueryAsync<DashboardRegionalDistributionDto>(query);
            var list = result.ToList();
            decimal total = list.Sum(x => x.TotalRevenue);
            if (total > 0)
            {
                foreach (var item in list)
                {
                    item.Percentage = Math.Round((double)(item.TotalRevenue / total * 100), 1);
                }
            }
            return list;

        }

        public async Task<PagedResult<DashboardTopSellingProductsDto>> TopSellingProductsAsync(int page, int pageSize)
        {
            string countQuery = "SELECT COUNT(DISTINCT ProductId) FROM OrderDetails";
            using var connection = _context.CreateConnection();

            int totalCount = await connection.ExecuteScalarAsync<int>(countQuery);
            var items = await connection.QueryAsync<DashboardTopSellingProductsDto>(
                "GetTopSellingProducts",
                new { Offset = (page - 1) * pageSize, PageSize = pageSize },
                commandType: CommandType.StoredProcedure
            );

            return new PagedResult<DashboardTopSellingProductsDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}

