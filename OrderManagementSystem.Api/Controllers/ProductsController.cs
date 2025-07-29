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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service) => _service = service;

        [HttpPost]
        [SwaggerRequestExample(typeof(CreateProductDto), typeof(CreateProductDtoExample))]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var result = await _service.CreateProductAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetProductsAsync();
            return Ok(products);
        }
    }
}
