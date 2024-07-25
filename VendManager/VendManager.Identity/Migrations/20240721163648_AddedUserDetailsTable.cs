using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendManager.Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailNotificationIntervalMinutes = table.Column<int>(type: "int", nullable: true),
                    EmailNotificationOnlyOutStockPeriodMinutes = table.Column<int>(type: "int", nullable: true),
                    EmailNotificationLastProcessedAtDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SMSNotificationIntervalMinutes = table.Column<int>(type: "int", nullable: true),
                    SMSlNotificationOnlyOutStockPeriodMinutes = table.Column<int>(type: "int", nullable: true),
                    SMSlNotificationLastProcessedAtDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AspNetUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_AspNetUsers_AspNetUserId",
                        column: x => x.AspNetUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_AspNetUserId",
                table: "UserDetails",
                column: "AspNetUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac502",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3dae7394-0018-4f07-a48d-540b87520cdb", "AQAAAAIAAYagAAAAEKchgTtSqYsVqvZ5klWYy5ATKqnkBUsErBnAAMBmVyTjkt6gsma/4/yVQbVwYZ9cWA==", "9497016a-2780-4090-966e-bac4c23d4bd6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82aa9131-f8ed-4aa4-b997-92a8671ac503",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ed6771b-8fbe-42b4-bb14-df69dba7d683", "AQAAAAIAAYagAAAAEJImdNFuiqEo1KPd7xTpN0/Ls+pyE7/iJD+WnVWPJcHGNm8T4vQsqd0nzNwthsO2mQ==", "f7eaf75b-f415-4605-b1b0-7b1a8c3b808d" });
        }
    }
}
