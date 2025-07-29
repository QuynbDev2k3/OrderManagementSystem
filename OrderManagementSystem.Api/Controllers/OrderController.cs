using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Api.SwaggerExamples;
using OrderManagementSystem.Application.DTOs;
using OrderManagementSystem.Application.Services;
using Swashbuckle.AspNetCore.Filters;

namespace OrderManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service) => _service = service;

        [HttpPost]
        [SwaggerRequestExample(typeof(CreateProductDto), typeof(CreateProductDtoExample))]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            var result = await _service.CreateOrderAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var orders = await _service.GetOrdersAsync(fromDate, toDate);
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await _service.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
