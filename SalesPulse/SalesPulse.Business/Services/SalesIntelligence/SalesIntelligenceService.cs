using SalesPulse.Core.DTOs.Common;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;
using SalesPulse.DataAccess.Repositories.SalesIntelligence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.SalesIntelligence
{
    public class SalesIntelligenceService(ISalesIntelligenceRepository _salesIntelligenceRepository) : ISalesIntelligenceService
    {
        public async Task<CategoryHeatmapDto> GetCategoryMonthlyPerformanceHeatmapAsync(SalesIntelligenceFilterDto filter)
        {
            return await _salesIntelligenceRepository.GetCategoryMonthlyPerformanceHeatmapAsync(filter);
        }

        public async Task<CohortMatrixDto> GetCustomerRetentionCohortAsync(SalesIntelligenceFilterDto filter)
        {
            return await _salesIntelligenceRepository.GetCustomerRetentionCohortAsync(filter);
        }

        public async Task<SalesIntelligenceKpiDto> GetKpiMetricsAsync(SalesIntelligenceFilterDto filter)
        {
            return await _salesIntelligenceRepository.GetKpiMetricsAsync(filter);
        }

        public async Task<PagedResult<SalesIntelligenceTopRevenueCustomerDto>> GetTopRevenueCustomersAsync(SalesIntelligenceFilterDto filter)
        {
            return await _salesIntelligenceRepository.GetTopRevenueCustomersAsync(filter);
        }

        public async Task<IEnumerable<TopRevenueProductDto>> GetTopRevenueProductAsync(SalesIntelligenceFilterDto filter)
        {
            return await _salesIntelligenceRepository.GetTopRevenueProductAsync(filter);
        }
    }
}
