using OrderManagementSystem.Application.DTOs;

namespace OrderManagementSystem.Application.Services;

public interface IProductService
{
    Task<ProductDto> CreateProductAsync(CreateProductDto dto);
    Task<List<ProductDto>> GetProductsAsync();
}