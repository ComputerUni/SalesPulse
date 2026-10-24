using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.OrderExplorers;
using SalesPulse.Core.DTOs.OrderExplorerDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelOrderExplorerViewComponents
{
    public class _PanelOrderExplorerDetailDrawerViewComponent(IOrderExplorerService _orderExplorerService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string orderCode)
        {
            if (string.IsNullOrWhiteSpace(orderCode))
            {
                orderCode = Request.Query["orderCode"].ToString();
            }

            if (string.IsNullOrWhiteSpace(orderCode))
            {
                return View((OrderExplorerDetailItemDto?)null);
            }

            orderCode = orderCode.Trim();
            if (!orderCode.StartsWith("#"))
            {
                orderCode = "#" + orderCode;
            }

            var detail = await _orderExplorerService.GetOrderDetailItemAsync(orderCode);
            return View(detail);
        }
    }
}
