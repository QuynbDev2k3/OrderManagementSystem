using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Infrastructure.Data;

namespace OrderManagementSystem.Application.Services;

public class OrderService : IOrderService
{
    private readonly AppDbContext _context;
    public OrderService(AppDbContext context) => _context = context;
    
    public async Task<OrderDto> CreateOrderAsync(CreateOrderDto dto)
    {
        // Lấy Customer hoặc tạo mới
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Name.ToLower() == dto.CustomerName.ToLower());

        if (customer == null)
        {
            customer = new Customer
            {
                CustomerId = Guid.NewGuid(),
                Name = dto.CustomerName,
                Email = "Customer@gmail.com",
                Phone = "0000000000",
                Address = "Customer",
                
            };
            _context.Customers.Add(customer);
        }

        var order = new Order
        {
            Customer = customer,
            ClientId = Guid.Parse("00000000-0000-0000-0000-000000000000"),
        };

        foreach (var item in dto.product)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductCode == item.ProductCode);

            if (product == null) throw new Exception($"Product {item.ProductCode} not found");

            order.Products.Add(new OrderProduct
            {
                Product = product,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            });
        }

        order.CalculateTotals();
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return new OrderDto
        {
            OrderId = order.OrderId,
            CustomerName = customer.Name,
            TotalAmount = order.TotalAmount,
            VAT = order.VAT,
            GrandTotal = order.GrandTotal,
            CreatedAt = order.CreatedAt
        };
    }

    public async Task<List<OrderDto>> GetOrdersAsync(DateTime? fromDate, DateTime? toDate)
    {
        var query = _context.Orders.Include(o => o.Customer).AsQueryable();

        if (fromDate.HasValue) query = query.Where(o => o.CreatedAt >= fromDate.Value);
        if (toDate.HasValue) query = query.Where(o => o.CreatedAt <= toDate.Value);

        return await query
            .Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                CustomerName = o.Customer.Name,
                TotalAmount = o.TotalAmount,
                VAT = o.VAT,
                GrandTotal = o.GrandTotal,
                CreatedAt = o.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<OrderDto?> GetOrderByIdAsync(Guid id)
    {
        var order = await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.Products)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(o => o.OrderId == id);

        if (order == null) return null;

        return new OrderDto
        {
            OrderId = order.OrderId,
            CustomerName = order.Customer.Name,
            TotalAmount = order.TotalAmount,
            VAT = order.VAT,
            GrandTotal = order.GrandTotal,
            CreatedAt = order.CreatedAt,
            lstProduct = order.Products.Select(i => new OrderProductDto()
            {
                ProductCode = i.Product.ProductCode,
                ProductName = i.Product.Name,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                SubTotal = i.Quantity * i.UnitPrice
            }).ToList()
        };
    }
}