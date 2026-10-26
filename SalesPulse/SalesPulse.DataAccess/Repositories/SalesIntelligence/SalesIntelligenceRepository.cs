using Dapper;
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
    }
}
