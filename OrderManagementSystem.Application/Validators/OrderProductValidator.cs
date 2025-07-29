using FluentValidation;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Validators;

public class OrderProductValidator : AbstractValidator<OrderProduct>
{
    public OrderProductValidator()
    {
        RuleFor(p => p.OrderProductId).NotEmpty();
        RuleFor(p => p.ProductCode).NotEmpty();
        RuleFor(p => p.OrderId).NotEmpty();
        RuleFor(p => p.Quantity).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(p => p.UnitPrice).NotEmpty();
    }
}