using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.Dashboards;

namespace SalesPulse.WebUI.ViewComponents._PanelDashboardViewComponents
{
    public class _PanelDashboardRegionalDistributionViewComponent(IDashboardService _dashboardService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(DateTime? startDate, DateTime? endDate)
        {
            var regional = await _dashboardService.RegionalDistributionAsync(startDate, endDate);
            return View(regional);
        }
    }
}
