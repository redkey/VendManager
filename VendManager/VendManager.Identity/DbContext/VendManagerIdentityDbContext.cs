using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VendManager.Identity.Models;

namespace VendManager.Identity.DbContext
{
    public class VendManagerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public VendManagerIdentityDbContext(DbContextOptions<VendManagerIdentityDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserDetails> UserDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserDetails>()
                 .HasOne(u => u.AspNetUser) // UserDetails has one ApplicationUser
                 .WithOne(au => au.UserDetails) // ApplicationUser has one UserDetails
                 .HasForeignKey<UserDetails>(u => u.AspNetUserId); // Foreign key on UserDetails

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(VendManagerIdentityDbContext).Assembly);
        }
    }
}
