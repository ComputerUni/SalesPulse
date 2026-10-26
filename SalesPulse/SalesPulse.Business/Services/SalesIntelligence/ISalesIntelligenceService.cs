using SalesPulse.Core.DTOs.SalesIntelligenceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Business.Services.SalesIntelligence
{
    public interface ISalesIntelligenceService
    {
        Task<SalesIntelligenceKpiDto> GetKpiMetricsAsync(SalesIntelligenceFilterDto filter);
    }
}
