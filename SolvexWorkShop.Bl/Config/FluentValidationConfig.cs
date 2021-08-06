using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SolvexWorkShop.Bl.Validations;

namespace SolvexWorkShop.Bl.Config
{
    public static class FluentValidationConfig
    {
        public static IMvcBuilder ConfigFluentValidation(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(x =>
            {
                x.AutomaticValidationEnabled = false;
                x.RegisterValidatorsFromAssemblyContaining<WorkShopValidator>();
            });
            return builder;
        }
    }
}
