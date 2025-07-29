namespace OrderManagementSystem.Domain.Entities;

public class OrderProduct
{
    public Guid OrderProductId { get; set; }
    public string ProductCode { get; set; }
    public Guid OrderId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    
    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}