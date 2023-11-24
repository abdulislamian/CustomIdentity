using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class CreateCategory_SubCat_ProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0259f383-ab23-44ea-bd3f-9dcdba82b5fa",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8974f75b-9037-4f8e-8aaf-4d66fbca5a01",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "ADMIN" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0259f383-ab23-44ea-bd3f-9dcdba82b5fa",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "SUPERADMIN", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8974f75b-9037-4f8e-8aaf-4d66fbca5a01",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "ADMIN", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b9ed3c1-f32a-4b79-91dc-8ffaf3b96e8b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65677bbe-03ce-496a-a45d-8d53a536fad9", "AQAAAAIAAYagAAAAEOmmKVtumAemG4Tif1EukCjDS3quLwj5TWYXhRZYmlsl5Vn54H3UIxdtxSS2IqkJXA==", "8d20151d-fe89-4c51-a25b-d22facab85b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d66f3123-77d1-4109-b4ec-f11a10dafeae",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a654da1-9056-43ee-b7ea-8041d3d63da5", "AQAAAAIAAYagAAAAEGYpLRXdrOwNfeFVoTs/ZeLnbK7F19hVIr03q2SNRwFiVtWoy5sQ0IEb+ze4Ssv7rg==", "b00ab13c-ff4c-4b5d-8080-3dae00f011bf" });
        }
    }
}
