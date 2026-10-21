using Microsoft.AspNetCore.Mvc;

namespace SalesPulse.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
