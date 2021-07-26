using FluentValidation;
using SolvexWorkShop.Bl.Dto;

namespace SolvexWorkShop.Bl.Validations
{
    public class WorkShopDayValidator : AbstractValidator<WorkShopDayDto>
    {
        public WorkShopDayValidator()
        {
            RuleFor(x => x.Day)
                .Empty()
                .WithMessage("WorkShopDay's Day is required");
            RuleFor(x => x.Mode)
                .Empty()
                .WithMessage("WorkShopDay's Mode is required");
            RuleFor(x => x.ModeLocation)
                .Empty()
                .WithMessage("WorkShopDay's ModeLocation is required");
            RuleFor(x => x.StartHour)
                .Empty()
                .WithMessage("WorkShopDay's StartHour is required");
            RuleFor(x => x.WorkShopId)
                .Empty()
                .WithMessage("WorkShopDay's WorkShopId is required");
        }
    }
}
