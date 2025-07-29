using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Domain.Entities;
using OrderManagementSystem.Infrastructure.Data;

namespace OrderManagementSystem.Application.Services;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;
    public ProductService(AppDbContext context) => _context = context;
    
    public async Task<ProductDto> CreateProductAsync(CreateProductDto dto)
    {
        var product = new Product
        {
            ProductCode = dto.ProductCode,
            Name = dto.Name,
            Price = dto.Price,
            Unit = dto.Unit
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return new ProductDto
        {
            ProductCode = product.ProductCode,
            Name = product.Name,
            Price = product.Price,
            Unit = product.Unit
        };
    }

    public async Task<List<ProductDto>> GetProductsAsync()
    {
        return await _context.Products
            .Select(p => new ProductDto
            {
                ProductCode = p.ProductCode,
                Name = p.Name,
                Price = p.Price,
                Unit = p.Unit
            })
            .ToListAsync();
    }
}