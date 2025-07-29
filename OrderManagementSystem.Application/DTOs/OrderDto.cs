namespace OrderManagementSystem.Application.DTOs;

public class OrderDto
{
    public Guid OrderId { get; set; }
    public string CustomerName { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public decimal VAT { get; set; }
    public decimal GrandTotal { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderProductDto> lstProduct { get; set; }
}