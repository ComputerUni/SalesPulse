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
        Task<DashboardMonthlySalesTrendDto> MonthlySalesTrendAsync(DateTime? startDate, DateTime? endDate);
        Task<DashboardOrderStatusDistributionDto> MonthlyOrderStatusDistributionAsync(DateTime? startDate, DateTime? endDate);
    }
}
//Teslim Edildi, Beklemede, İptal Edildi, Kargoda, İade Edildi bu durumlar var