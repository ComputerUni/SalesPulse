using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.Dashboards;

namespace SalesPulse.WebUI.ViewComponents._PanelDashboardViewComponents
{
    public class _PanelDashboardKpiCardsViewComponent(IDashboardService _dashboardService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate, DateTime? endDate)
        {
            var kpiCards = await _dashboardService.KpiCardsAsync(startDate, endDate);
            return View(kpiCards);
        }
    }
}
