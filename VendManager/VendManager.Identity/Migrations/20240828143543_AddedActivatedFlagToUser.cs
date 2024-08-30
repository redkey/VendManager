using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendManager.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddedActivatedFlagToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activated",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                columns: new[] { "Activated", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "1ac05a57-c841-4f31-b4f3-0f444cb401c4", "AQAAAAIAAYagAAAAEPzaFk+ZRV3bvi3O7mCOliEeoKTw1R2STMi1C3Bw0Fx/nlP35e4STNF3Dc+j2r+7+A==", "6dba7b96-1c68-4ee2-acee-a2c0e559e367" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                columns: new[] { "Activated", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "c81d64e0-482e-4207-9275-f573b100fb93", "AQAAAAIAAYagAAAAEMZ924j4ZfbmhW0DYdJFl5wpB+Yo2N3nzf8QPFgLk4qiMlUBGHFmqciG8BKXxO6Q1g==", "34215ace-ad03-405b-9ba6-e652723d26b0" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activated",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4041b692-09f8-48e8-a004-d7c8d15b505b", "AQAAAAIAAYagAAAAEKCfx4QL7gWi5bGB4AP3zekA9g4OUm+4mQSVehMxYmr2g8wtpLtX6pq4lYv/EhhSyQ==", "0164c6e9-afee-4e68-8bc6-53bfcd900885" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a93eab1-397d-418a-a79a-8c70055d6948", "AQAAAAIAAYagAAAAEEVrwfiaBSJUkJwz/+Ql+tvoh6zGCdnv6WCz8hBQ/eEwuRO7zcnBAjvusivuzXff1g==", "20686f93-3fe4-406d-a5f2-d511616e5c9e" });
        }
    }
}
