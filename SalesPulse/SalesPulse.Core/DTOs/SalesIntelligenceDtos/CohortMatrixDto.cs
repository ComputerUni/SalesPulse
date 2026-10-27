using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.SalesIntelligenceDtos
{
    public class CohortMatrixDto
    {
        public int Months { get; set; }
        public List<CohortMatrixRowDto> Rows { get; set; } = new();
    }

    public class CohortMatrixRowDto
    {
        public DateTime CohortDate { get; set; }
        public string CohortName { get; set; }
        public int InitialCustomers { get; set; }
        public Dictionary<int, decimal?> RetentionRates { get; set; } = new();
    }
}
