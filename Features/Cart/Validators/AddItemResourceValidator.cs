using BackendTest.Features.Cart.Resources;
using FluentValidation;

namespace BackendTest.Features.Cart.Validators;

public class AddItemResourceValidator : AbstractValidator<AddItemResource>
{
    public AddItemResourceValidator()
    {
        RuleFor(x => x.CartId).NotEmpty().WithMessage($"{nameof(AddItemResource.CartId)} cannot be empty");
        RuleFor(x => x.ItemId).NotEmpty().WithMessage($"{nameof(AddItemResource.ItemId)} cannot be empty");
        RuleFor(x => x.Quantity).NotEmpty().WithMessage($"{nameof(AddItemResource.Quantity)} cannot be empty");
    }
}
