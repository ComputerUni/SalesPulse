using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.OrderExplorers;
using SalesPulse.Core.DTOs.OrderExplorerDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelOrderExplorerViewComponents
{
    public class _PanelOrderExplorerTableViewComponent(IOrderExplorerService _orderExplorerService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(OrderExplorerFilterDto filter)
        {
            filter ??= new OrderExplorerFilterDto();
            var values = await _orderExplorerService.OrderExplorerListItemAsync(filter);
            return View(values);
        }
    }
}
