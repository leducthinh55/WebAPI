using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ktttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "PromotionPrice",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Vote",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ModifiedProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifyDate = table.Column<DateTime>(nullable: false),
                    OldPrice = table.Column<decimal>(nullable: false),
                    NewPrice = table.Column<decimal>(nullable: false),
                    OldQuantity = table.Column<decimal>(nullable: false),
                    NewQuantity = table.Column<decimal>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifiedProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifiedProducts_AspNetUsers_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModifiedProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImangeUrl = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedProducts_ModifiedBy",
                table: "ModifiedProducts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedProducts_ProductId",
                table: "ModifiedProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ProductId",
                table: "ProductDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModifiedProducts");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PromotionPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "Products");
        }
    }
}
