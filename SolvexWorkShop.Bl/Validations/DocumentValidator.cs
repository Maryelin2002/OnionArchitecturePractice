using FluentValidation;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Bl.Validations
{
    public class DocumentValidator : AbstractValidator<DocumentDto>
    {
        public DocumentValidator()
        {
            RuleFor(x => x.FileName)
                .MinimumLength(10)
                .WithMessage("Document's length must be at least 10 characters")
                .NotEmpty()
                .WithMessage("Document's filename is required");
        }
    }
}
