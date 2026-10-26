using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.SalesIntelligence;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelSalesIntelligenceViewComponents
{
    public class _PanelSalesIntelligenceAnalyticsKpiCardsViewComponent(ISalesIntelligenceService _salesIntelligenceService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(SalesIntelligenceFilterDto filter)
        {
            var kpiCards = await _salesIntelligenceService.GetKpiMetricsAsync(filter);
            return View(kpiCards);
        }
    }
}
