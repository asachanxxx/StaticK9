using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaticK9.F.MainUI.Areas.Identity.Data;
using StaticK9.F.MainUI.Data;

[assembly: HostingStartup(typeof(StaticK9.F.MainUI.Areas.Identity.IdentityHostingStartup))]
namespace StaticK9.F.MainUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<StaticK9FMainUIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("StaticK9FMainUIContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<StaticK9FMainUIContext>();
            });
        }
    }
}