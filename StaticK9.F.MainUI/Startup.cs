using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StaticK9.F.Infrastructure;
using StaticK9.F.Repositories;

namespace StaticK9.F.MainUI
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
            /*
             * This will add Authorize to all the controllers in the application
             */
            //services.AddControllersWithViews(oo => oo.Filters.Add(new AuthorizeFilter()));

            /*
             * THis will Add authorize to all the Razer Pages
             */
            services.AddRazorPages().AddMvcOptions(oo => oo.Filters.Add(new AuthorizeFilter()));

            services.AddControllersWithViews();
            services.AddSingleton<ISystemConfigurations, SystemConfigurations>();
            services.AddSingleton<IUserRepository, UserRepository>();

            /*
             * When we add Cookie Auth then if some controller or Razer page has been authorized then it will redeirect to 
             * https://localhost:44364/Account/Login?ReturnUrl=%2F
             * If you want to override this default path 
             * services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(oo=>oo.LoginPath = "/Account/Signin");
             */
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
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
                endpoints.MapRazorPages();
            });
        }
    }
}
