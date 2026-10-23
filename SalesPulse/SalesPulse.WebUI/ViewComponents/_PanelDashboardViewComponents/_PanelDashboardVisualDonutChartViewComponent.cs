using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.Dashboards;

namespace SalesPulse.WebUI.ViewComponents._PanelDashboardViewComponents
{
    public class _PanelDashboardVisualDonutChartViewComponent(IDashboardService _dashboardService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var data = await _dashboardService.MonthlyOrderStatusDistributionAsync(startDate, endDate);
            return View(data);
        }
    }
}
