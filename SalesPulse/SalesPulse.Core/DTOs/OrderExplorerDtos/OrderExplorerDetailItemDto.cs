namespace SalesPulse.Core.DTOs.OrderExplorerDtos

{
    public class OrderExplorerDetailItemDto
    {
        public string OrderCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PaymentMethod { get; set; }
        public string City { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderExplorerDetailProductItemDto> OrderItems { get; set; } = new();
    }
}
