using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.SalesIntelligence;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelSalesIntelligenceViewComponents
{
    public class _PanelSalesIntelligenceTopRevenueCustomersViewComponent(ISalesIntelligenceService _salesIntelligenceService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(SalesIntelligenceFilterDto filter)
        {
            var topRevenues = await _salesIntelligenceService.GetTopRevenueCustomersAsync(filter);
            return View(topRevenues);
        }
    }
}
