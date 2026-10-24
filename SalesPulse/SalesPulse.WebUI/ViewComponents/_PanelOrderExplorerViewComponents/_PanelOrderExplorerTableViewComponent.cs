using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.OrderExplorers;
using SalesPulse.Core.DTOs.OrderExplorerDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelOrderExplorerViewComponents
{
    public class _PanelOrderExplorerTableViewComponent(IOrderExplorerService _orderExplorerService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int page = int.TryParse(Request.Query["page"], out var p) && p > 0 ? p : 1;
            int pageSize = int.TryParse(Request.Query["pageSize"], out var ps) && ps > 0 ? ps : 25;

            var filter = new OrderExplorerFilterDto
            {
                Page = page,
                PageSize = pageSize
            };

            var values = await _orderExplorerService.OrderExplorerListItemAsync(filter);

            return View(values);
        }
    }
}
