using Microsoft.AspNetCore.Mvc;
using SalesPulse.Core.DTOs.OrderExplorerDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelOrderExplorerViewComponents
{
    public class _PanelOrderExplorerFilterRibbonViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(OrderExplorerFilterDto? filter)
        {
            filter ??= new OrderExplorerFilterDto();
            return View(filter);
        }
    }
}
