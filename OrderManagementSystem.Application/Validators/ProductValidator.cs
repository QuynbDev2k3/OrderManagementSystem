using OrderManagementSystem.Domain.Entities;
using FluentValidation;

namespace OrderManagementSystem.Application.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.ProductCode).NotEmpty().MaximumLength(50);
        RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
        RuleFor(p => p.Quantity).GreaterThanOrEqualTo(0);
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Unit).NotEmpty();
    }
}