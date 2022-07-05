using DSR_Summer_Practice.WEB.Data.Repository;
using Microsoft.EntityFrameworkCore;
using DSR_Summer_Practice.WEB.Interfaces;
using DSR_Summer_Practice.WEB.XMLFunctions;

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
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection));
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IXMLService, XMLService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
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
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DbObjects dbObjects = new(new XMLService());
                dbObjects.Initial(content);
            }
        }
    }
}