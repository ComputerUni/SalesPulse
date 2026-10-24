using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.DashboardDtos;

namespace SalesPulse.DataAccess.Repositories.Dashboards
{
    public interface IDashboardRepository
    {
        Task<DashboardKpiCardDto> KpiCardsAsync(DateTime? startDate, DateTime? endDate);
        Task<IEnumerable<DashboardCategoryPerformanceDto>> CategoryPerformanceAsync(DateTime? startDate, DateTime? endDate);
        Task<IEnumerable<DashboardRegionalDistributionDto>> RegionalDistributionAsync(DateTime? startDate, DateTime? endDate);
        Task<PagedResult<DashboardTopSellingProductsDto>> TopSellingProductsAsync(int page, int pageSize);
        Task<DashboardMonthlySalesTrendDto> MonthlySalesTrendAsync(DateTime? startDate, DateTime? endDate);
        Task<DashboardOrderStatusDistributionDto> MonthlyOrderStatusDistributionAsync(DateTime? startDate, DateTime? endDate);
    }
}
