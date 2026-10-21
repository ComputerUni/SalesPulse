using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.DashboardDtos;

namespace SalesPulse.DataAccess.Repositories.Dashboards
{
    public interface IDashboardRepository
    {
        Task<DashboardKpiCardDto> KpiCardsAsync();
        Task<IEnumerable<DashboardCategoryPerformanceDto>> CategoryPerformanceAsync();
        Task<IEnumerable<DashboardRegionalDistributionDto>> RegionalDistributionAsync();
        Task<PagedResult<DashboardTopSellingProductsDto>> TopSellingProductsAsync(int page, int pageSize);
    }
}
