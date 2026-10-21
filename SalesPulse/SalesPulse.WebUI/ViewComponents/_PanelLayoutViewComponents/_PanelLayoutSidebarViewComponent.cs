using Microsoft.AspNetCore.Mvc;

namespace SalesPulse.WebUI.ViewComponents._PanelLayoutViewComponents
{
    public class _PanelLayoutSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
