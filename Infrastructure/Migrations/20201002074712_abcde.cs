using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class abcde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name2",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "ImangeUrl",
                table: "ProductTypes");
            migrationBuilder.DropColumn(
                name: "Position",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductTypes");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name2",
                table: "ProductTypes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
