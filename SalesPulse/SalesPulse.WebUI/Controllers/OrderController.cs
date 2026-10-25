using Microsoft.AspNetCore.Mvc;
using SalesPulse.Core.DTOs.OrderExplorerDtos;

namespace SalesPulse.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index([FromQuery] OrderExplorerFilterDto filter)
        {
            return View(filter);
        }
    }
}
