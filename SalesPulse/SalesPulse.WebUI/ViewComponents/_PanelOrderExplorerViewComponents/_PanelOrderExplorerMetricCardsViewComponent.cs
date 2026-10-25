using Microsoft.AspNetCore.Mvc;
using SalesPulse.Business.Services.OrderExplorers;
using SalesPulse.Core.DTOs.OrderExplorerDtos;

namespace SalesPulse.WebUI.ViewComponents._PanelOrderExplorerViewComponents
{
    public class _PanelOrderExplorerMetricCardsViewComponent(IOrderExplorerService _orderExplorerService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(OrderExplorerFilterDto? filter)
        {
            var kpiCards = await _orderExplorerService.OrderExplorerKpiCardsAsync(filter);
            return View(kpiCards);
        }
    }
}
