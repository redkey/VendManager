using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendManager.Identity.Models;

namespace VendManager.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                    Email = "admin@vendmanager.co",
                    NormalizedEmail = "ADMIN@VENDMANAGER.CO",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@vendmanager.co",
                    PasswordHash = hasher.HashPassword(null, "*Winning2024"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                    Email = "customer@vendmanager.co",
                    NormalizedEmail = "CUSTOMER@VENDMANAGER.CO",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "customer@vendmanager.co",
                    PasswordHash = hasher.HashPassword(null, "*Winning2024"),
                    EmailConfirmed = true
                }
            );
        }
    }
}

