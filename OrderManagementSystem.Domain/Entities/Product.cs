namespace OrderManagementSystem.Domain.Entities;

public class Product
{
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Unit { get; set; }
    
    public ICollection<OrderProduct> OrderProduct { get; set; } = new List<OrderProduct>();
}