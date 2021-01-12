using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class porn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeGroupUserId",
                table: "TypeGroups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeGroupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeGroupUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeGroups_TypeGroupUserId",
                table: "TypeGroups",
                column: "TypeGroupUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeGroups_TypeGroupUsers_TypeGroupUserId",
                table: "TypeGroups",
                column: "TypeGroupUserId",
                principalTable: "TypeGroupUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeGroups_TypeGroupUsers_TypeGroupUserId",
                table: "TypeGroups");

            migrationBuilder.DropTable(
                name: "TypeGroupUsers");

            migrationBuilder.DropIndex(
                name: "IX_TypeGroups_TypeGroupUserId",
                table: "TypeGroups");

            migrationBuilder.DropColumn(
                name: "TypeGroupUserId",
                table: "TypeGroups");
        }
    }
}
