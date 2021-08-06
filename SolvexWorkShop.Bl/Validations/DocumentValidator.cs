using FluentValidation;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Bl.Validations
{
    public class DocumentValidator : AbstractValidator<DocumentDto>
    {
        public DocumentValidator()
        {
            RuleFor(x => x.FileName)
                .MinimumLength(5)
                .WithMessage("Document's FileName length must be at least 5 characters")
                .NotEmpty()
                .WithMessage("Document's FileName is required");
        }
    }
}
