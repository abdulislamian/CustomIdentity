using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllClaimsForSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permission", "Permissions.Account.Create", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 2, "Permission", "Permissions.Account.View", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 3, "Permission", "Permissions.Account.Edit", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 4, "Permission", "Permissions.Account.Delete", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 5, "Permission", "Permissions.Product.Create", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 6, "Permission", "Permissions.Product.View", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 7, "Permission", "Permissions.Product.Edit", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 8, "Permission", "Permissions.Product.Delete", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 9, "Permission", "Permissions.Category.Create", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 10, "Permission", "Permissions.Category.View", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 11, "Permission", "Permissions.Category.Edit", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 12, "Permission", "Permissions.Category.Delete", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 13, "Permission", "Permissions.SubCategory.Create", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 14, "Permission", "Permissions.SubCategory.View", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 15, "Permission", "Permissions.SubCategory.Edit", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" },
                    { 16, "Permission", "Permissions.SubCategory.Delete", "0259f383-ab23-44ea-bd3f-9dcdba82b5fa" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6e2f5ff5-d58e-4a94-80ce-6658fd7813b7", "AQAAAAIAAYagAAAAEGGAFDqs5rB8jdyKZeGNQ494AuxvD06iQWiiarKIJUETJ0//pOgcfzRNx1YKtk5wKw==", "961fa0cf-3fa1-4445-9b0e-2d4d188d77c0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d66f3123-77d1-4109-b4ec-f11a10dafeae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba95962-fc64-4f77-af4a-8f1c10777754", "AQAAAAIAAYagAAAAEOpAsks/H9fgWXCQapNaxP/ieUGAFH4ojLwJMVTYksRhaiXkeuUzxelFnfoO8AlAzA==", "921a8794-ba08-4ece-b365-41673adc1aee" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c494d7db-deea-42a3-b2f0-a859da82bedf", "AQAAAAIAAYagAAAAEK6s4xLow8cwnv7bye0SBW9IJWB3ZrvxgOsfc5uWLRuRbGigy3VpqC2bFSEK3Ptc/Q==", "259ba7f7-3b43-4030-8209-640bec1119ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d66f3123-77d1-4109-b4ec-f11a10dafeae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0c8c06b-be11-46b7-96db-65b1f54fbf4e", "AQAAAAIAAYagAAAAEKfevmWgjdMMGcGPeLlo1+POjBPLZZNCtfr8tMsxCjLzvgQvqXo8YDMb9OKbecXXEg==", "a355a662-b4a0-416c-9298-d90e062800f3" });
        }
    }
}
