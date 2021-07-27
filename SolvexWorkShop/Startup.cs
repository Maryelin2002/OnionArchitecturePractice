using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SolvexWorkshop.Model.IoC;
using SolvexWorkShop.Bl.Config;
using SolvexWorkShop.Config;
using SolvexWorkShop.Core.Settings;
using SolvexWorkShop.Services.IoC;

namespace SolvexWorkShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region App Settings

            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));

            #endregion

            #region CORS

            services.AddCors(options =>
            {
                options.AddPolicy("MainPolicy",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();

                        //TODO: remove this line for production
                        builder.SetIsOriginAllowed(x => true);
                    });
            });

            #endregion

            #region External Dependencies

            services.ConfigSqlServerDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllers(options => options.EnableEndpointRouting = false)
                .ConfigFluentValidation();
            services.ConfigAutoMapper();
            services.ConfigSerilog();

            #endregion

            #region App Registries

            services.AddModelRegistry();
            services.AddServiceRegistry();

            #endregion

            #region API Libraries

            services.ConfigJwtAuth(Configuration);
            services.ConfigOData();
            services.ConfigSwagger();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAppSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
