using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.Dashboards;

namespace SalesPulse.WebUI.ViewComponents._PanelDashboardViewComponents
{
    public class _PanelDashboardDualAxisTrendChartViewComponent(IDashboardService _dashboardService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var data = await _dashboardService.DashboardMonthlySalesTrendAsync(startDate, endDate);
            return View(data);
        }
    }
}
