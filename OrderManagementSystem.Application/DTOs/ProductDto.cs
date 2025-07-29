namespace OrderManagementSystem.Application.DTOs;

public class ProductDto
{
    public string ProductCode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Unit { get; set; } = null!;
}