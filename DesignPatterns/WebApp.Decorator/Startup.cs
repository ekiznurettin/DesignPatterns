using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApp.Decorator.Decorators;
using WebApp.Decorator.Models;
using WebApp.Decorator.Repositories;

namespace BaseProject
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
            //1. yol
            //services.AddScoped<IProductRepository>(sp => {
            //    var context = sp.GetRequiredService<AppIdentityDbContext>();
            //    var productRepository = new ProductRepository(context);
            //    var memoryCache = sp.GetRequiredService<IMemoryCache>();
            //    var logService = sp.GetRequiredService<ILogger<ProductRepositoryLoggingDecorator>>();
            //    var cacheDecorator = new ProductRepositoryCacheDecorator(productRepository, memoryCache);
            //    var logDecorator = new ProductRepositoryLoggingDecorator(cacheDecorator, logService);
            //    return logDecorator;
            //});

            //2. Yol
            services.AddScoped<IProductRepository, ProductRepository>()
                .Decorate<IProductRepository, ProductRepositoryCacheDecorator>()
                .Decorate<IProductRepository, ProductRepositoryLoggingDecorator>();

            services.AddMemoryCache();

            services.AddDbContext<AppIdentityDbContext>(options => { options.UseSqlServer(Configuration.GetConnectionString("SqlServer")); });
            services.AddIdentity<AppUser, IdentityRole>(options => { 
            options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
