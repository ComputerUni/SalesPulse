using Microsoft.AspNetCore.Mvc;

namespace SalesPulse.WebUI.ViewComponents._PanelLayoutViewComponents
{
    public class _PanelLayoutHeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
