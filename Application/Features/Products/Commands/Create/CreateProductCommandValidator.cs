using FluentValidation;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
public CreateProductCommandValidator()
{
    RuleFor(c => c.Name).NotEmpty();
    RuleFor(c => c.Price).NotEmpty().GreaterThan(0m);
    RuleFor(c => c.Quantity).NotEmpty().GreaterThan(0);
    RuleFor(c => c.Description).NotEmpty();
}
}
