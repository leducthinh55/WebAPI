using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class fafdaf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Products_ProductType_ProductTypeId",
            //    table: "Products");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ProductType_TypeGroups_TypeGroupId",
            //    table: "ProductType");

            migrationBuilder.CreateTable(
               name: "ProductTypes",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   ImangeUrl = table.Column<string>(nullable: true),
                   Position = table.Column<string>(nullable: true),
                   Color = table.Column<string>(nullable: true),
                   TypeGroupId = table.Column<int>(nullable: false)
               })
               ;


            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_ProductTypes_ProductTypeId",
            //    table: "Products",
            //    column: "ProductTypeId",
            //    principalTable: "ProductTypes",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

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
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_TypeGroups_TypeGroupId",
                table: "ProductTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_TypeGroupId",
                table: "ProductType",
                newName: "IX_ProductType_TypeGroupId");

            migrationBuilder.AlterColumn<int>(
                name: "TypeGroupId",
                table: "ProductType",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductType",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_TypeGroups_TypeGroupId",
                table: "ProductType",
                column: "TypeGroupId",
                principalTable: "TypeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
