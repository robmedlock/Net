using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebClient.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ClassLibrary.Repository.EF;
using ClassLibrary.Service;
using ClassLibrary.Repository;

namespace WebClient
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            //additional configuration

            //add additional DbContext if separate security database 
            services.AddEntityFrameworkSqlServer().AddDbContext<EcommerceContext>(
     options => options.UseSqlServer(
                   Configuration.GetConnectionString("EcommerceConnection")));


            //specify implementation of IEcommerceService 
            //services registered with AddTransient are disposed after the request
            services.AddTransient<IEcommerceService, EcommerceService>(ctx =>
            {
                EcommerceContext context = ctx.GetService<EcommerceContext>();
                return new EcommerceService(new ProductRepository(context),
                                            new OrderRepository(context));
            });

            //services registered with AddTransient are disposed after the request
            services.AddTransient<IProductRepositoryAsync, ProductRepository>(ctx =>
            {
                EcommerceContext context = ctx.GetService<EcommerceContext>();
                return new ProductRepository(context);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                    pattern: "{controller=Product}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "areaRoute",
                   pattern: "{area}/{controller}/{action}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
