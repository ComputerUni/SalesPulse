using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.Dashboards;

namespace SalesPulse.WebUI.ViewComponents._PanelDashboardViewComponents
{
    public class _PanelDashboardCategoryPerformanceViewComponent(IDashboardService _dashboardService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate, DateTime? endDate)
        {
            var performance = await _dashboardService.CategoryPerformanceAsync(startDate, endDate);
            return View(performance);
        }
    }
}
