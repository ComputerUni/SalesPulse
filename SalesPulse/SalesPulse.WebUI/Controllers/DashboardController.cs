using Microsoft.AspNetCore.Mvc;
using SalesPulse.Core.DTOs.DashboardDtos;

namespace SalesPulse.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index(DateTime? startDate, DateTime? endDate)
        {
            var filter = new DashboardFilterDto
            {
                StartDate = startDate,
                EndDate = endDate
            };
            return View(filter);
        }

        public async Task<IActionResult> TopSellingProductsPartial(int page = 1)
        {
            return ViewComponent("_PanelDashboardTopSellingProducts", new { page });
        }
    }
}
