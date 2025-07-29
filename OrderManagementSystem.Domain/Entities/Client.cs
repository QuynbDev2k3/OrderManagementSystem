namespace OrderManagementSystem.Domain.Entities;

public class Client
{
    public Guid ClientId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string CreateBy { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}