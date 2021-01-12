using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class xnxxes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable("ProductTypes");

            //migrationBuilder.RenameTable(
            //    name: "ProductTypes",
            //    newName: "ProductType");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ProductTypes_TypeGroupId",
            //    table: "ProductType",
            //    newName: "IX_ProductType_TypeGroupId");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ProductTypeId",
            //    table: "Products",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier");

            //migrationBuilder.AlterColumn<int>(
            //    name: "TypeGroupId",
            //    table: "ProductType",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldDefaultValue: 0);

            //migrationBuilder.AlterColumn<string>(
            //    name: "Name",
            //    table: "ProductType",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(250)",
            //    oldMaxLength: 250);

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "ProductType",
            //    nullable: false,
            //    oldClrType: typeof(Guid),
            //    oldType: "uniqueidentifier")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ProductType",
            //    table: "ProductType",
            //    column: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_ProductType_ProductTypeId",
            //    table: "Products",
            //    column: "ProductTypeId",
            //    principalTable: "ProductType",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductType_TypeGroups_TypeGroupId",
            //    table: "ProductType",
            //    column: "TypeGroupId",
            //    principalTable: "TypeGroups",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_TypeGroups_TypeGroupId",
                table: "ProductType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductType_TypeGroupId",
                table: "ProductTypes",
                newName: "IX_ProductTypes_TypeGroupId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductTypeId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TypeGroupId",
                table: "ProductTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductTypes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ProductTypes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_TypeGroups_TypeGroupId",
                table: "ProductTypes",
                column: "TypeGroupId",
                principalTable: "TypeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
