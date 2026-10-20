namespace SalesPulse.Core.DTOs.OrderDetailDtos
{
    public class CreateOrderDetailDto
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
