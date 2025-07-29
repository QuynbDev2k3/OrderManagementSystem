namespace OrderManagementSystem.Domain.Entities;

public class Customer
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}