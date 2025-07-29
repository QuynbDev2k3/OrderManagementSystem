using OrderManagementSystem.Application.DTOs;

namespace OrderManagementSystem.Application.Services;

public interface IOrderService
{
    Task<OrderDto> CreateOrderAsync(CreateOrderDto dto);
    Task<List<OrderDto>> GetOrdersAsync(DateTime? fromDate, DateTime? toDate);
    Task<OrderDto?> GetOrderByIdAsync(Guid id);
}