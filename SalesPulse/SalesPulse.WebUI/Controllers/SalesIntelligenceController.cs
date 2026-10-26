using Microsoft.AspNetCore.Mvc;
using SalesPulse.Core.DTOs.SalesIntelligenceDtos;

namespace SalesPulse.WebUI.Controllers
{
    public class SalesIntelligenceController : Controller
    {
        public IActionResult Index(SalesIntelligenceFilterDto filter)
        {
            filter ??= new SalesIntelligenceFilterDto();
            return View(filter);
        }
    }
}
