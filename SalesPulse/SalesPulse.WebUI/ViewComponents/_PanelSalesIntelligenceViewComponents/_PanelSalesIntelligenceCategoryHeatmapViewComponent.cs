using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.SalesIntelligence;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelSalesIntelligenceViewComponents
{
    public class _PanelSalesIntelligenceCategoryHeatmapViewComponent(ISalesIntelligenceService _salesIntelligenceService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(SalesIntelligenceFilterDto filter)
        {
            var categories = await _salesIntelligenceService.GetCategoryMonthlyPerformanceHeatmapAsync(filter);
            return View(categories);
        }
    }
}
