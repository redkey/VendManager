using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendManager.Identity.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEnabledColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "AspNetUsers",
                newName: "Deleted");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                columns: new[] { "Activated", "ConcurrencyStamp", "Deleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "2ce6dcbc-e2ed-47d1-a93b-ea4281ef4085", false, "AQAAAAIAAYagAAAAEAq9XojUoanXAAILIVayTMXcvNs4h+ZO2kA1ib27WNHaIOPWnmMh6bLT6tdcsdgyXQ==", "e2afc71e-d2fb-448b-92a8-cab6c95b7714" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                columns: new[] { "Activated", "ConcurrencyStamp", "Deleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { false, "0513ac0b-120f-498f-84da-fa4553aca1a5", false, "AQAAAAIAAYagAAAAEJstFXkoWsAZad3zVSnLE0eFCZPvP5IRFaDKJrLlZ4lKIRLQ54aFfDKQgTMA4UuzIg==", "7c2b5af4-f939-4758-854b-b38786d6039b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "AspNetUsers",
                newName: "Enabled");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                columns: new[] { "Activated", "ConcurrencyStamp", "Enabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "1ac05a57-c841-4f31-b4f3-0f444cb401c4", true, "AQAAAAIAAYagAAAAEPzaFk+ZRV3bvi3O7mCOliEeoKTw1R2STMi1C3Bw0Fx/nlP35e4STNF3Dc+j2r+7+A==", "6dba7b96-1c68-4ee2-acee-a2c0e559e367" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                columns: new[] { "Activated", "ConcurrencyStamp", "Enabled", "PasswordHash", "SecurityStamp" },
                values: new object[] { true, "c81d64e0-482e-4207-9275-f573b100fb93", true, "AQAAAAIAAYagAAAAEMZ924j4ZfbmhW0DYdJFl5wpB+Yo2N3nzf8QPFgLk4qiMlUBGHFmqciG8BKXxO6Q1g==", "34215ace-ad03-405b-9ba6-e652723d26b0" });
        }
    }
}
