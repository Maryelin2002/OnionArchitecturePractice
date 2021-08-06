using FluentValidation;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Bl.Validations
{
    public class WorkShopValidator : AbstractValidator<WorkShopDto>
    {
        public WorkShopValidator()
        {
            RuleFor(x => x.Name)
                .MinimumLength(10)
                .WithMessage("WorkShop's Name length must be at least 10 characters")
                .NotEmpty()
                .WithMessage("WorkShop's Name is required");
            RuleFor(x => x.Description)
                .MaximumLength(150)
                .WithMessage("WorkShop's Description must be less then 150 characters")
                .NotEmpty()
                .WithMessage("WorkShop's Description is required");
            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("WorkShop's StartDate is required");
            RuleFor(x => x.ContentSupport)
                .NotEmpty()
                .WithMessage("WorkShop's ContentSupport is required");


        }
    }
}
