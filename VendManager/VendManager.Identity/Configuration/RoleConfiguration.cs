using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VendManager.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "912aa3de-41c0-4d5c-a76a-70ba779bde06",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"

                },
                new IdentityRole
                {
                    Id = "fc08c638-2c38-481f-97f8-d1cc853337ed",
                    Name = "Admin",
                    NormalizedName = "ADMIN"

                }
            );
        }
    }
}
