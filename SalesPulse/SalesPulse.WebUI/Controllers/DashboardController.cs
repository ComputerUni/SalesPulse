using Microsoft.AspNetCore.Mvc;

namespace SalesPulse.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TopSellingProductsPartial(int page = 1)
        {
            return ViewComponent("_PanelDashboardTopSellingProducts", new { page });
        }
    }
}
