using SalesPulse.Core.DTOs.SalesIntelligenceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.DataAccess.Repositories.SalesIntelligence
{
    public interface ISalesIntelligenceRepository
    {
        Task<SalesIntelligenceKpiDto> GetKpiMetricsAsync(SalesIntelligenceFilterDto filter);
    }
}
