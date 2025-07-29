using FluentValidation;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Validators;

public class OrderValidator : AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(p => p.OrderId).NotEmpty();
        RuleFor(p => p.CustomerId).NotEmpty();
        RuleFor(p => p.ClientId).NotEmpty();
        RuleFor(p => p.CreatedAt).NotEmpty();
    }
}