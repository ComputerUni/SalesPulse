using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.SalesIntelligence;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelSalesIntelligenceViewComponents
{
    public class _PanelSalesIntelligenceCohortRetentionMatrixViewComponent(ISalesIntelligenceService _salesIntelligenceService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(SalesIntelligenceFilterDto filter)
        {
            var cohorts = await _salesIntelligenceService.GetCustomerRetentionCohortAsync(filter);
            return View(cohorts);
        }
    }
}
