using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebClient.Data;
using WebClient.Models;
using WebClient.Services;
using System.IO;
using System.Reflection;
using ClassLibrary.EntityFramework;
using ClassLibrary.RepositoryInterfaces;
using ClassLibrary.ServiceInterfaces;

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
            //change name of connection string if required
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AuthenticationConnection")));

            //add additional DbContext
            services.AddDbContext<EcommerceContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EcommerceConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            
            services.AddMvc();

            services.AddTransient<IEmailSender, EmailSender>();

            //services registered with AddTransient are disposed after the request
            services.AddTransient<IEcommerceService, EcommerceService>(ctx =>
            {
                EcommerceContext context = ctx.GetService<EcommerceContext>();
                return new EcommerceService(new ProductRepository(context), new OrderRepository(context));
            });

            //services registered with AddTransient are disposed after the request
            services.AddTransient<IEcommerceService, EcommerceService>(ctx =>
            {
                EcommerceContext context = ctx.GetService<EcommerceContext>();
                return new EcommerceService(new ProductRepository(context), new OrderRepository(context));
            });

            //services registered with AddTransient are disposed after the request
            services.AddTransient<IProductRepositoryAsync, ProductRepository>(ctx =>
            {
                EcommerceContext context = ctx.GetService<EcommerceContext>();
                return new ProductRepository(context);
            });

            //password requirements
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 1;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //change default route 
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Product}/{action=Index}/{id?}");
            });
        }
    }
}
