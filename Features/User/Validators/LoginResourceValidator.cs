using BackendTest.Features.User.Resources;
using FluentValidation;

namespace BackendTest.Features.User.Validators;

public class LoginResourceValidator : AbstractValidator<LoginResource>
{
    public LoginResourceValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage($"{nameof(LoginResource.Email)} cannot be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage($"{nameof(LoginResource.Password)} cannot be empty");
    }
}
