namespace OrderManagementSystem.Application.DTOs;

public class CreateOrderProductDto
{
    public string ProductCode { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}