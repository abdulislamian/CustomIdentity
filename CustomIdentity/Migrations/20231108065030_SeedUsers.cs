using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b", 0, "5cb12513-2d07-47ee-83cf-fcf0eee2bac3", "superadmin@gmail.com", true, false, null, "Super Admin", null, null, "AQAAAAIAAYagAAAAENIb/ODY9bZqnmHNxJKumXTA/hgyKYCQIb5AOkL8yoUps5vNC1w+B09FpVJh7hk7oA==", null, false, "36499b95-a94f-46fb-8df3-0079b10fdd83", false, "superadmin@gmail.com" },
                    { "d66f3123-77d1-4109-b4ec-f11a10dafeae", 0, "b885d97a-9bc6-4f88-98ee-2990f95d8fee", "basicuser@gmail.com", true, false, null, "Basic User", null, null, "AQAAAAIAAYagAAAAEFv98YC1Et82El9cydpTcliq0aLb+281AuQVGmC33GXlWQe6K/Wq0JBfwGxmy8i+8A==", null, false, "6e15ed5e-655f-484e-97c5-56d15cc8a102", false, "basicuser@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d66f3123-77d1-4109-b4ec-f11a10dafeae");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b", 0, "21ad3108-2a61-4313-a673-b22d041f4831", "superadmin@gmail.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEG8j8fbatUsgQB7Xy6+xoPREb4L2vvbKg6aK5Qd40sw9vC6E1A58mNrp/AlqCpPBCw==", null, false, "e020c6b7-2127-4b7b-bd01-f12b60f8d699", false, "superadmin@gmail.com" },
                    { "d66f3123-77d1-4109-b4ec-f11a10dafeae", 0, "221148a4-27dc-4f33-86cc-2dcc1e409563", "basicuser@gmail.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEJbqRbvmzKYCfXcu5rEFlzMfi6Y/hIHR+m4BsCTz5GJW9TgLLTbmSh1LQ0uL39YUAA==", null, false, "6dc0a622-059e-444a-849d-7581f590d922", false, "basicuser@gmail.com" }
                });
        }
    }
}
