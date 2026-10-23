using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.DashboardDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Dashboards
{
    public interface IDashboardService
    {
        Task<DashboardKpiCardDto> KpiCardsAsync();
        Task<IEnumerable<DashboardCategoryPerformanceDto>> CategoryPerformanceAsync();
        Task<IEnumerable<DashboardRegionalDistributionDto>> RegionalDistributionAsync();
        Task<PagedResult<DashboardTopSellingProductsDto>> TopSellingProductsAsync(int page, int pageSize);
        Task<DashboardMonthlySalesTrendDto> DashboardMonthlySalesTrendAsync(DateTime? startDate, DateTime? endDate);
        Task<DashboardOrderStatusDistributionDto> MonthlyOrderStatusDistributionAsync(DateTime? startDate, DateTime? endDate);
    }
}
