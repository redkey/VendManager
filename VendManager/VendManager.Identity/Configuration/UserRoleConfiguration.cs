using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendManager.Identity.Models;

namespace VendManager.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = "fc08c638-2c38-481f-97f8-d1cc853337ed",
                        UserId = "82aa9131-f8ed-4aa4-b997-92a8671ac502"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "912aa3de-41c0-4d5c-a76a-70ba779bde06",
                        UserId = "82aa9131-f8ed-4aa4-b997-92a8671ac503"
                    }
                );
        }
    }
}
