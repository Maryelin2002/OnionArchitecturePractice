using Microsoft.Extensions.DependencyInjection;
using SolvexWorkshop.Model.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SolvexWorkShop.Bl.Config
{
    public static class SqlServerDbConfig
    {
        public static IServiceCollection ConfigSqlServerDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<WorkShopContext>(options => options.UseSqlServer(connection));

            return services;
        }
    }
}
