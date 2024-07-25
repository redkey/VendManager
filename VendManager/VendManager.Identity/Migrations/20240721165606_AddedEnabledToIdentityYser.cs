using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendManager.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddedEnabledToIdentityYser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                columns: new[] { "ConcurrencyStamp", "Enabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4041b692-09f8-48e8-a004-d7c8d15b505b", true, "AQAAAAIAAYagAAAAEKCfx4QL7gWi5bGB4AP3zekA9g4OUm+4mQSVehMxYmr2g8wtpLtX6pq4lYv/EhhSyQ==", "0164c6e9-afee-4e68-8bc6-53bfcd900885" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                columns: new[] { "ConcurrencyStamp", "Enabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a93eab1-397d-418a-a79a-8c70055d6948", true, "AQAAAAIAAYagAAAAEEVrwfiaBSJUkJwz/+Ql+tvoh6zGCdnv6WCz8hBQ/eEwuRO7zcnBAjvusivuzXff1g==", "20686f93-3fe4-406d-a5f2-d511616e5c9e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c82d9b38-da31-451f-a5ca-d5187e140f03", "AQAAAAIAAYagAAAAEP2zJP43HfDqdhYyd6mn5rp3JFKRuH4LoLXXJLPQx73OHOo6pqamZ1AxIO3/uunbEw==", "582a8e6d-fe0d-4b8f-ba3f-77b160d0d216" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6bdf8e5a-9f54-4710-ab9b-e348dabf4eae", "AQAAAAIAAYagAAAAEOz5bVV4S209Ia/RprgfK39OqKlnXlTRM7RwensDYrsUF/t0u48bg3sd570bortvCA==", "d0335048-5407-47a5-8d8e-0d6fa2d3af7d" });
        }
    }
}
