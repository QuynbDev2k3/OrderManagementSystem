namespace OrderManagementSystem.Domain.Entities;

public class Order
{
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public Guid ClientId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public decimal TotalAmount { get; private set; }
    public decimal VAT { get; private set; }
    public decimal GrandTotal { get; private set; }

    public Customer Customer { get; set; } = null!;
    public Client Client { get; set; } = null!;
    public ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();

    // Hàm tính tiền
    public void CalculateTotals()
    {
        TotalAmount = Products.Sum(i => i.Quantity * i.UnitPrice);
        VAT = TotalAmount * 0.1m;
        GrandTotal = TotalAmount + VAT;
    }
}