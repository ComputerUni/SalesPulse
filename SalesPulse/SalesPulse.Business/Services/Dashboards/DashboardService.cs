using SalesPulse.Core.DTOs.DashboardDtos;
using SalesPulse.DataAccess.Repositories.Dashboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.Dashboards
{
    public class DashboardService(IDashboardRepository _dashboardRepository) : IDashboardService
    {
        public async Task<IEnumerable<DashboardCategoryPerformanceDto>> CategoryPerformanceAsync()
        {
            return await _dashboardRepository.CategoryPerformanceAsync();
        }

        public async Task<DashboardKpiCardDto> KpiCardsAsync()
        {
            return await _dashboardRepository.KpiCardsAsync();
        }

        public async Task<IEnumerable<DashboardRegionalDistributionDto>> RegionalDistributionAsync()
        {
            return await _dashboardRepository.RegionalDistributionAsync();
        }
    }
}
