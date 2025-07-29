using FluentValidation;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Validators;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.CustomerId).NotEmpty();
        RuleFor(p => p.Name).NotEmpty().MaximumLength(50);
        RuleFor(p => p.Email).NotEmpty().EmailAddress().MaximumLength(50);
        RuleFor(p => p.Phone).NotEmpty().MaximumLength(15);
        RuleFor(p => p.Address).NotEmpty().MaximumLength(100);
    }
}