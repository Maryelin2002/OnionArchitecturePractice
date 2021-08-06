using FluentValidation;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Bl.Validations
{
    public class WorkShopDayValidator : AbstractValidator<WorkShopDayDto>
    {
        public WorkShopDayValidator()
        {
            RuleFor(x => x.Day)
                .NotNull()
                .WithMessage("WorkShopDay's Day is required");
            RuleFor(x => x.Mode)
                .NotNull()
                .WithMessage("WorkShopDay's Mode is required");
            RuleFor(x => x.ModeLocation)
                .NotNull()
                .WithMessage("WorkShopDay's ModeLocation is required");
            RuleFor(x => x.StartHour)
                .NotNull()
                .WithMessage("WorkShopDay's StartHour is required");
            RuleFor(x => x.WorkShopId)
                .NotNull()
                .WithMessage("WorkShopDay's WorkShopId is required");
        }
    }
}
