using FluentValidation;

namespace Application.Features.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.UserNameOrEmail).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();  
    }
}