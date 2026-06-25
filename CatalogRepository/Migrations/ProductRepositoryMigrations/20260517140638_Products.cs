using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogRepository.Migrations.ProductRepositoryMigrations
{
    /// <inheritdoc />
    public partial class Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCost = table.Column<int>(type: "int", nullable: false),
                    GST = table.Column<int>(type: "int", nullable: false),
                    ProductTotalCost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "GST", "ImageFilePath", "ProductCost", "ProductDescription", "ProductName", "ProductTotalCost", "TypeId" },
                values: new object[] { new Guid("09046394-9a84-448e-beba-6915ebde6287"), new Guid("d0b25a95-adee-46f8-988b-85f5fab5883b"), 18, "path/to/image1.jpg", 100, "Description for Product 1", "Product 1", 118, new Guid("fd8e5ac8-8d67-494e-8b31-0fbbed587462") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
