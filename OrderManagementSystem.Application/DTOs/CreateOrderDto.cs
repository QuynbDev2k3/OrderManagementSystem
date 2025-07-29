namespace OrderManagementSystem.Application.DTOs;

public class CreateOrderDto
{
    public string CustomerName { get; set; } = null!;
    public List<CreateOrderProductDto> product { get; set; } = new();
}