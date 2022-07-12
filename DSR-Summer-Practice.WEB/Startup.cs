using DSR_Summer_Practice.DAL.EF;
using DSR_Summer_Practice.DAL.Interfaces;
using DSR_Summer_Practice.DAL.Repositories;
using DSR_Summer_Practice.Services.Interfaces;
using DSR_Summer_Practice.Services.Services;
using DSR_Summer_Practice.Shared.Repositories;
using DSR_Summer_Practice.Shared.Services;
using Microsoft.EntityFrameworkCore;

namespace DSR_Summer_Practice.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddScoped<IExchangeRateService, ExchangeRateService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}"
                );
            });
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContext content = scope.ServiceProvider.GetRequiredService<AppDBContext>();
                DbObjects dbObjects = new DbObjects(new ValCursRepository(new ValCursDeserializerXML()));
                dbObjects.Initial(content);
            }
        }
    }
}