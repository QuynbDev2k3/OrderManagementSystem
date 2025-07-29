using OrderManagementSystem.Application.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace OrderManagementSystem.Api.SwaggerExamples;

public class CreateProductDtoExample : IExamplesProvider<CreateProductDto>
{
    public CreateProductDto GetExamples()
    {
        return new CreateProductDto
        {
            ProductCode = "APP001",
            Name = "App 1",
            Price = 25000000,
            Unit = "App"
        };
    }
}