using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesPulse.Core.DTOs.SalesIntelligenceDtos
{
    public class CohortRetentionRawDto
    {
        public DateTime CohortDate { get; set; }
        public string CohortName { get; set; }
        public int InitialCustomers { get; set; }
        public int MonthIndex { get; set; }
        public decimal RetentionRate { get; set; }
    }
}
