using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreateBy",
                table: "Products",
                column: "CreateBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreateBy",
                table: "Products",
                column: "CreateBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreateBy",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreateBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Products");
        }
    }
}
