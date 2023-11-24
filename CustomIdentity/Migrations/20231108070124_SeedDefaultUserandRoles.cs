using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUserandRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0259f383-ab23-44ea-bd3f-9dcdba82b5fa", null, "SUPERADMIN", null },
                    { "056ca257-19fc-4499-88b5-903cda6bd9d7", null, "User", "USER" },
                    { "8974f75b-9037-4f8e-8aaf-4d66fbca5a01", null, "ADMIN", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b", 0, "65677bbe-03ce-496a-a45d-8d53a536fad9", "superadmin@gmail.com", true, false, null, "Super Admin", null, null, "AQAAAAIAAYagAAAAEOmmKVtumAemG4Tif1EukCjDS3quLwj5TWYXhRZYmlsl5Vn54H3UIxdtxSS2IqkJXA==", null, false, "8d20151d-fe89-4c51-a25b-d22facab85b7", false, "superadmin@gmail.com" },
                    { "d66f3123-77d1-4109-b4ec-f11a10dafeae", 0, "9a654da1-9056-43ee-b7ea-8041d3d63da5", "basicuser@gmail.com", true, false, null, "Basic User", null, null, "AQAAAAIAAYagAAAAEGYpLRXdrOwNfeFVoTs/ZeLnbK7F19hVIr03q2SNRwFiVtWoy5sQ0IEb+ze4Ssv7rg==", null, false, "b00ab13c-ff4c-4b5d-8080-3dae00f011bf", false, "basicuser@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0259f383-ab23-44ea-bd3f-9dcdba82b5fa", "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b" },
                    { "8974f75b-9037-4f8e-8aaf-4d66fbca5a01", "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "056ca257-19fc-4499-88b5-903cda6bd9d7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0259f383-ab23-44ea-bd3f-9dcdba82b5fa", "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8974f75b-9037-4f8e-8aaf-4d66fbca5a01", "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d66f3123-77d1-4109-b4ec-f11a10dafeae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0259f383-ab23-44ea-bd3f-9dcdba82b5fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8974f75b-9037-4f8e-8aaf-4d66fbca5a01");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b");
        }
    }
}
