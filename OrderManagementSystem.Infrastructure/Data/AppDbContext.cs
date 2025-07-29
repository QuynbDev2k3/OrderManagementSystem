using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<Product> Products => Set<Product>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Client
        modelBuilder.Entity<Client>(e =>
        {
            e.HasKey(c => c.ClientId);
            e.Property(c => c.UserName).IsRequired().HasMaxLength(50);
            e.Property(c => c.Password).IsRequired().HasMaxLength(50);
            e.Property(c => c.Role).IsRequired().HasMaxLength(50);
            e.Property(c => c.CreateBy).IsRequired().HasMaxLength(50);
            e.HasMany(c => c.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId);
        });
        
        // Customer
        modelBuilder.Entity<Customer>(e =>
        {
            e.HasKey(c => c.CustomerId);
            e.Property(c => c.Name).IsRequired().HasMaxLength(100);
            e.Property(c => c.Email).IsRequired().HasMaxLength(50);
            e.Property(c => c.Phone).IsRequired().HasMaxLength(15);
            e.Property(c => c.Address).IsRequired().HasMaxLength(100);
            e.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);
        });

        // Order
        modelBuilder.Entity<Order>(e =>
        {
            e.HasKey(o => o.OrderId);
            e.Property(c => c.CustomerId).IsRequired();
            e.Property(c => c.ClientId).IsRequired();
            e.Property(c => c.CreatedAt).IsRequired();
            e.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            e.Property(o => o.VAT).HasColumnType("decimal(18,2)");
            e.Property(o => o.GrandTotal).HasColumnType("decimal(18,2)");
        });

        // OrderItem
        modelBuilder.Entity<OrderProduct>(e =>
        {
            e.HasKey(oi => oi.OrderProductId);
            e.Property(c => c.ProductCode).IsRequired();
            e.Property(c => c.OrderId).IsRequired();
            e.Property(c => c.Quantity).IsRequired().HasColumnType("int");
            e.Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
            e.HasOne(oi => oi.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(oi => oi.OrderId);
            e.HasOne(oi => oi.Product)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(oi => oi.ProductCode);
        });
        
        // Product
        modelBuilder.Entity<Product>(e =>
        {
            e.HasKey(p => p.ProductCode);
            e.Property(c => c.Name).IsRequired().HasMaxLength(100);
            e.Property(c => c.Quantity).IsRequired().HasColumnType("int");
            e.Property(p => p.Price).HasColumnType("decimal(18,2)");
            e.Property(c => c.Unit).IsRequired().HasMaxLength(50);
        });
    }
}