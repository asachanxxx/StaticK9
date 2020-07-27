using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StaticK9.F.MainUI.Areas.Identity.Data;

namespace StaticK9.F.MainUI.Data
{
    public class StaticK9FMainUIContext : IdentityDbContext<ApplicationUser>
    {
        public StaticK9FMainUIContext(DbContextOptions<StaticK9FMainUIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
