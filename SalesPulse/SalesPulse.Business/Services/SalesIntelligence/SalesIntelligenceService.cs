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
        public Task<SalesIntelligenceKpiDto> GetKpiMetricsAsync(SalesIntelligenceFilterDto filter)
        {
            return _salesIntelligenceRepository.GetKpiMetricsAsync(filter);
        }
    }
}
