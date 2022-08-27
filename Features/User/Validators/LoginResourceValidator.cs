using BackendTest.Features.User.Resources;
using FluentValidation;

namespace BackendTest.Features.User.Validators;

public class LoginResourceValidator : AbstractValidator<LoginResource>
{
    public LoginResourceValidator()
    {
        RuleFor(x => x.Username).NotEmpty().WithMessage($"{nameof(LoginResource.Username)} cannot be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage($"{nameof(LoginResource.Password)} cannot be empty");
    }
}
