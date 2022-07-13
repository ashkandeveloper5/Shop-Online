using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Myket_Shop.Migrations
{
    public partial class AddMyketShopMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryToProducts",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryToProducts", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryToProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "فروش موبایل", "موبایل" },
                    { 2, "ساعت مجی", "ساعت مجی" },
                    { 3, "لباس", "لباس" },
                    { 4, "لوازم خانگی", "لوازم خانگی" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { 1, 236.0m, 5 },
                    { 2, 899.0m, 6 },
                    { 3, 300.0m, 7 },
                    { 4, 100.0m, 12 },
                    { 5, 120.0m, 4 },
                    { 6, 900.0m, 1 },
                    { 7, 5100.0m, 2 },
                    { 8, 3300.0m, 9 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ItemId", "Name" },
                values: new object[,]
                {
                    { 1, "I Learn Wpf", 1, "دوربین مدل 2" },
                    { 2, "I Learn Full Asp.net Core Advance", 2, "دوربین مدل 3" },
                    { 3, "Learn Full AnfularJs", 3, "دوربین مدل 4" },
                    { 4, "Learn Full AnfularJs", 4, "دوربین مدل 5" },
                    { 5, "Learn Full AnfularJs", 5, "تیشرت" },
                    { 6, "Learn Full AnfularJs", 6, "لپ تاپ مدل 1" },
                    { 7, "Learn Full AnfularJs", 7, "لپ تاپ مدل 2" },
                    { 8, "Learn Full AnfularJs", 8, "گوشی" }
                });

            migrationBuilder.InsertData(
                table: "CategoryToProducts",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 8 },
                    { 1, 8 },
                    { 4, 7 },
                    { 3, 7 },
                    { 2, 7 },
                    { 1, 7 },
                    { 4, 6 },
                    { 3, 6 },
                    { 2, 6 },
                    { 1, 6 },
                    { 4, 5 },
                    { 3, 5 },
                    { 2, 5 },
                    { 1, 5 },
                    { 4, 4 },
                    { 3, 4 },
                    { 2, 4 },
                    { 1, 4 },
                    { 4, 3 },
                    { 3, 3 },
                    { 2, 3 },
                    { 1, 3 },
                    { 4, 2 },
                    { 3, 2 },
                    { 2, 2 },
                    { 1, 2 },
                    { 4, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 3, 8 },
                    { 4, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryToProducts_ProductId",
                table: "CategoryToProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ItemId",
                table: "Products",
                column: "ItemId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryToProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
