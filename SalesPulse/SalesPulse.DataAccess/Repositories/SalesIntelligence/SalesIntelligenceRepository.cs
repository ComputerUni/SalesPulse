using Dapper;
using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;
using SalesPulse.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.SalesIntelligence
{
    public class SalesIntelligenceRepository(AppDbContext _context) : ISalesIntelligenceRepository
    {
        public async Task<CategoryHeatmapDto> GetCategoryMonthlyPerformanceHeatmapAsync(SalesIntelligenceFilterDto filter)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", filter.StartDate, DbType.DateTime);
            parameters.Add("@EndDate", filter.EndDate, DbType.DateTime);

            var rawData = (await connection.QueryAsync<CategoryMonthlySalesRawDto>(
                "sp_GetCategoryMonthlyPerformanceHeatmap",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 120
            )).ToList();

            var result = new CategoryHeatmapDto();

            if (!rawData.Any())
                return result;

            var distinctMonths = rawData.Select(x => new { x.Year, x.Month }).Distinct().OrderBy(x => x.Year).ThenBy(x => x.Month).ToList();

            var tr = new System.Globalization.CultureInfo("tr-TR");

            foreach (var m in distinctMonths)
            {
                var dt = new DateTime(m.Year, m.Month, 1);
                result.Months.Add(new MonthHeaderDto
                {
                    Year = m.Year,
                    Month = m.Month,
                    MonthName = dt.ToString("MMM", tr)
                });
            }

            var groupedByCategory = rawData.GroupBy(x => new { x.CategoryId, x.CategoryName });
            foreach (var group in groupedByCategory)
            {
                var row = new CategoryHeatmapRowDto
                {
                    CategoryId = group.Key.CategoryId,
                    CategoryName = group.Key.CategoryName,
                    TotalPeriodRevenue = group.Sum(x => x.TotalRevenue)
                };

                foreach (var m in distinctMonths)
                {
                    var key = $"{m.Year}-{m.Month}";
                    var sale = group.FirstOrDefault(x => x.Year == m.Year && x.Month == m.Month);
                    row.MonthlyRevenues[key] = sale?.TotalRevenue ?? 0m;
                }

                result.Rows.Add(row);
            }

            result.Rows = result.Rows.OrderByDescending(r => r.TotalPeriodRevenue).ToList();
            result.MaxRevenue = rawData.Max(x => x.TotalRevenue);
            return result;

        }

        public async Task<SalesIntelligenceKpiDto> GetKpiMetricsAsync(SalesIntelligenceFilterDto filter)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", filter.StartDate, DbType.DateTime);
            parameters.Add("@EndDate", filter.EndDate, DbType.DateTime);

            return await connection.QueryFirstOrDefaultAsync<SalesIntelligenceKpiDto>(
                "sp_GetSalesIntelligenceKpiMetrics",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 120
            ) ?? new SalesIntelligenceKpiDto();
        }

        public async Task<PagedResult<SalesIntelligenceTopRevenueCustomerDto>> GetTopRevenueCustomersAsync(SalesIntelligenceFilterDto filter)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Page", filter.Page, DbType.Int32);
            parameters.Add("@PageSize", filter.PageSize, DbType.Int32);
            parameters.Add("@StartDate", filter.StartDate, DbType.DateTime);
            parameters.Add("@EndDate", filter.EndDate, DbType.DateTime);

            using var multi = await connection.QueryMultipleAsync(
                    "sp_GetTopRevenueCustomersPagedList",
                    parameters,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: 60
            );

            int totalCount = await multi.ReadFirstAsync<int>();
            var items = (await multi.ReadAsync<SalesIntelligenceTopRevenueCustomerDto>()).ToList();
            return new PagedResult<SalesIntelligenceTopRevenueCustomerDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = filter.Page,
                PageSize = filter.PageSize
            };

        }

        public async Task<IEnumerable<TopRevenueProductDto>> GetTopRevenueProductAsync(SalesIntelligenceFilterDto filter)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", filter.StartDate, DbType.DateTime);
            parameters.Add("@EndDate", filter.EndDate, DbType.DateTime);

            return await connection.QueryAsync<TopRevenueProductDto>(
                "sp_GetTopRevenueProducts",
                parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 120
            );
        }
    }
}
