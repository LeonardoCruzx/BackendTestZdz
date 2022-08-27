using BackendTest.Features.User.Resources;
using FluentValidation;

namespace BackendTest.Features.User.Validators;

public class SignUpResourceValidator : AbstractValidator<SignUpResource>
{
    public SignUpResourceValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage($"{nameof(SignUpResource.Email)} cannot be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage($"{nameof(SignUpResource.Password)} cannot be empty");
        RuleFor(x => x.Name).NotEmpty().WithMessage($"{nameof(SignUpResource.Name)} cannot be empty");
    }
}
