namespace SalesPulse.Core.DTOs.OrderDetailDtos
{
    public class ResultOrderDetailDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public int ProductId { get; set; }
        public int ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
