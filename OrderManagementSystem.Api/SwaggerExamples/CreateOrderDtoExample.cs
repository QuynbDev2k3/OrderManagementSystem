using OrderManagementSystem.Application.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace OrderManagementSystem.Api.SwaggerExamples;

public class CreateOrderDtoExample : IExamplesProvider<CreateOrderDto>
{
    public CreateOrderDto GetExamples()
    {
        return new CreateOrderDto
        {
            CustomerName = "Customer",
            product = new List<CreateOrderProductDto>
            {
                new CreateOrderProductDto
                {
                    ProductCode = "APP001",
                    Quantity = 2,
                    UnitPrice = 25000000
                },
                new CreateOrderProductDto
                {
                    ProductCode = "APP002",
                    Quantity = 1,
                    UnitPrice = 15000000
                }
            }
        };
    }
}