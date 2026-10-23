using Microsoft.AspNetCore.Mvc;

namespace SalesPulse.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
