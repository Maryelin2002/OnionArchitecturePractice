using Microsoft.Extensions.DependencyInjection;
using SolvexWorkShop.Services.Services;

namespace SolvexWorkShop.Services.IoC
{
    public static class ServiceRegistry
    {
        public static void AddServiceRegistry(this IServiceCollection services)
        {
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWorkShopService, WorkShopService>();
            services.AddScoped<IWorkShopMemberService, WorkShopMemberService>();
            services.AddScoped<IWorkShopDayService, WorkShopDayService>();
            
        }
    }
}
