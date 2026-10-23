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

        public async Task<DashboardOrderStatusDistributionDto> MonthlyOrderStatusDistributionAsync(DateTime? startDate, DateTime? endDate)
        {
            using var connection = _context.CreateConnection();
            if(!startDate.HasValue || !endDate.HasValue)
            {
                var maxDate = await connection.ExecuteScalarAsync<DateTime?>("SELECT TOP 1 CreatedAt FROM Orders ORDER BY CreatedAt DESC") ?? DateTime.Now;
                endDate ??= maxDate;
                startDate ??= maxDate.AddMonths(-12);
            }

            string query = "SELECT Status, COUNT(Id) AS OrderCount FROM Orders WITH (NOLOCK) WHERE CreatedAt >= @StartDate AND CreatedAt <= @EndDate GROUP BY Status ORDER BY OrderCount DESC";

            var items = (await connection.QueryAsync<DashboardOrderStatusItemDto>(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            })).ToList();

            var result = new DashboardOrderStatusDistributionDto
            {
                Items = items,
                TotalOrderCount = items.Sum(x => x.OrderCount)
            };

            if(result.TotalOrderCount > 0)
            {
                foreach(var item in result.Items)
                {
                    item.Percentage = Math.Round((double)item.OrderCount / result.TotalOrderCount * 100, 1);
                }
            }

            return result;
        }

        public async Task<DashboardMonthlySalesTrendDto> MonthlySalesTrendAsync(DateTime? startDate, DateTime? endDate)
        {
            using var connection = _context.CreateConnection();

            if (!startDate.HasValue || !endDate.HasValue)
            {
                var maxDate = await connection.ExecuteScalarAsync<DateTime?>("SELECT TOP 1 CreatedAt FROM Orders ORDER BY CreatedAt DESC") ?? DateTime.Now;
                endDate ??= maxDate;
                startDate ??= maxDate.AddMonths(-12);
            }

            string query = "SELECT YEAR(CreatedAt) AS Year, MONTH(CreatedAt) AS Month, ISNULL(SUM(TotalAmount), 0) AS TotalRevenue, COUNT(Id) AS TotalOrderCount FROM Orders WHERE CreatedAt >= @StartDate AND CreatedAt <= @EndDate GROUP BY YEAR(CreatedAt), MONTH(CreatedAt) ORDER BY Year ASC, Month ASC";

            var items = (await connection.QueryAsync<DashboardMonthlySalesItemDto>(query, new
            {
                StartDate = startDate,
                EndDate = endDate
            })).ToList();

            var culture = new System.Globalization.CultureInfo("tr-TR");
            foreach (var item in items)
            {
                item.MonthName = new DateTime(item.Year, item.Month, 1).ToString("MMM yy", culture);
            }

            var trendDto = new DashboardMonthlySalesTrendDto
            {
                MonthlyItems = items
            };

            if (items.Any())
            {
                trendDto.AverageMonthlyRevenue = items.Average(x => x.TotalRevenue);
                var peakItem = items.MaxBy(x => x.TotalRevenue);
                if (peakItem != null)
                {
                    trendDto.PeakMonth = peakItem.MonthName;
                    trendDto.PeakRevenue = peakItem.TotalRevenue;
                }

                var lastMonth = items.Last();
                if (trendDto.AverageMonthlyRevenue > 0)
                {
                    trendDto.TargetAchievementRate = Math.Round((double)(lastMonth.TotalRevenue / trendDto.AverageMonthlyRevenue) * 100, 1);
                }
            }

            return trendDto;
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

