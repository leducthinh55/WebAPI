using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class xnxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeGroupId",
                table: "ProductTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_TypeGroupId",
                table: "ProductTypes",
                column: "TypeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_TypeGroups_TypeGroupId",
                table: "ProductTypes",
                column: "TypeGroupId",
                principalTable: "TypeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_TypeGroups_TypeGroupId",
                table: "ProductTypes");

            migrationBuilder.DropTable(
                name: "TypeGroups");

            migrationBuilder.DropIndex(
                name: "IX_ProductTypes_TypeGroupId",
                table: "ProductTypes");

            migrationBuilder.DropColumn(
                name: "TypeGroupId",
                table: "ProductTypes");
        }
    }
}
