using Dapper;
using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.DashboardDtos;
using SalesPulse.DataAccess.Context;
using System.Data;


namespace SalesPulse.DataAccess.Repositories.Dashboards
{
    public class DashboardRepository(AppDbContext _context) : IDashboardRepository
    {
        public async Task<IEnumerable<DashboardCategoryPerformanceDto>> CategoryPerformanceAsync(DateTime? startDate, DateTime? endDate)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", startDate, DbType.DateTime);
            parameters.Add("@EndDate", endDate, DbType.DateTime);

            var result = await connection.QueryAsync<DashboardCategoryPerformanceDto>(
                "sp_GetTopCategoriesByRevenue",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 120
            );

            var list = result.ToList();
            decimal total = list.Sum(x => x.TotalRevenue);
            if (total > 0)
            {
                foreach (var item in list)
                {
                    item.Percentage = Math.Round((double)(item.TotalRevenue / total) * 100, 1);
                }
            }

            return list;

        }

        public async Task<DashboardKpiCardDto> KpiCardsAsync(DateTime? startDate, DateTime? endDate)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", startDate, DbType.DateTime);
            parameters.Add("@EndDate", endDate, DbType.DateTime);

            return await connection.QueryFirstOrDefaultAsync<DashboardKpiCardDto>(
                "sp_GetDashboardKpiCards",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60
            ) ?? new DashboardKpiCardDto();
        }

        public async Task<DashboardOrderStatusDistributionDto> MonthlyOrderStatusDistributionAsync(DateTime? startDate, DateTime? endDate)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", startDate, DbType.DateTime);
            parameters.Add("@EndDate", endDate, DbType.DateTime);

            var items = (await connection.QueryAsync<DashboardOrderStatusItemDto>(
                "sp_GetOrderStatusDistribution",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60
            )).ToList();

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

            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", startDate, DbType.DateTime);
            parameters.Add("@EndDate", endDate, DbType.DateTime);

            var items = (await connection.QueryAsync<DashboardMonthlySalesItemDto>(
                "sp_GetMonthlySalesTrend",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60
            )).ToList();

            var culture = new System.Globalization.CultureInfo("tr-TR");
            foreach(var item in items)
            {
                item.MonthName = new DateTime(item.Year, item.Month, 1).ToString("MMM yy", culture);
            }

            var trendDto = new DashboardMonthlySalesTrendDto
            {
                MonthlyItems = items
            };

            if(items.Any())
            {
                trendDto.AverageMonthlyRevenue = items.Average(x => x.TotalRevenue);
                var peakItem = items.MaxBy(x => x.TotalRevenue);
                if(peakItem != null)
                {
                    trendDto.PeakMonth = peakItem.MonthName;
                    trendDto.PeakRevenue = peakItem.TotalRevenue;
                }

                var lastMonth = items.Last();
                if(trendDto.AverageMonthlyRevenue > 0)
                {
                    trendDto.TargetAchievementRate = Math.Round((double)(lastMonth.TotalRevenue / trendDto.AverageMonthlyRevenue) * 100, 1);
                }
            }

            return trendDto;
        }

        public async Task<IEnumerable<DashboardRegionalDistributionDto>> RegionalDistributionAsync(DateTime? startDate, DateTime? endDate)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", startDate, DbType.DateTime);
            parameters.Add("@EndDate", endDate, DbType.DateTime);

            var result = await connection.QueryAsync<DashboardRegionalDistributionDto>(
                "sp_GetRegionalDistribution",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 60
            );

            var list = result.ToList();
            decimal total = list.Sum(x => x.TotalRevenue);

            if(total > 0)
            {
                foreach(var item in list)
                {
                    item.Percentage = Math.Round((double)(item.TotalRevenue / total) * 100, 1);
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

