using FluentValidation;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Validators;

public class ClientValidator : AbstractValidator<Client>
{
    public ClientValidator()
    {
        RuleFor(p => p.ClientId).NotEmpty();
        RuleFor(p => p.UserName).NotEmpty().MaximumLength(50);
        RuleFor(p => p.Password).NotEmpty().MaximumLength(50);
        RuleFor(p => p.Role).NotEmpty().MaximumLength(50);
        RuleFor(p => p.CreateBy).NotEmpty().MaximumLength(50);
    }
}