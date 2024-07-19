using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendManager.Identity.Models;

namespace VendManager.Identity.DbContext
{
    public class VendManagerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public VendManagerIdentityDbContext(DbContextOptions<VendManagerIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(VendManagerIdentityDbContext).Assembly);
        }
    }
}
