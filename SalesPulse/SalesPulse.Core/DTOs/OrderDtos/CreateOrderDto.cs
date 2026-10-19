namespace SalesPulse.Core.DTOs.OrderDtos
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
