using FluentValidation;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Bl.Validations
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("User's Name is required");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("User's LastName is required");
            RuleFor(x => x.DocumentType)
                .NotNull()
                .WithMessage("User's DocumentType is required");
            RuleFor(x => x.Gender)
                .NotNull()
                .WithMessage("User's Gender is required");
        }
    }
}
