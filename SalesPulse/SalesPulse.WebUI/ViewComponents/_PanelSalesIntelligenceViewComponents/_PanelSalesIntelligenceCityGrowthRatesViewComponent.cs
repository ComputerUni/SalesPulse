using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.SalesIntelligence;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelSalesIntelligenceViewComponents
{
    public class _PanelSalesIntelligenceCityGrowthRatesViewComponent(ISalesIntelligenceService _salesIntelligenceService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(SalesIntelligenceFilterDto filter)
        {
            var cities = await _salesIntelligenceService.GetTopCitySalesAsync(filter);
            return View(cities);
        }
    }
}
