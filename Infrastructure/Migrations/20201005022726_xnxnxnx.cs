using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class xnxnxnx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductDetails");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ProductDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_ColorId",
                table: "ProductDetails",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Colors_ColorId",
                table: "ProductDetails",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Colors_ColorId",
                table: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_ColorId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ProductDetails");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
