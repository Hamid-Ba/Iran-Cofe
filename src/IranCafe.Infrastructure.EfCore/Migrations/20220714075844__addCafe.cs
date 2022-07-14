using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IranCafe.Infrastructure.EfCore.Migrations
{
    public partial class _addCafe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafe_City_CityId",
                table: "Cafe");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Cafe_CafeId",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cafe_CafeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafe",
                table: "Cafe");

            migrationBuilder.RenameTable(
                name: "Cafe",
                newName: "Cafes");

            migrationBuilder.RenameIndex(
                name: "IX_Cafe_CityId",
                table: "Cafes",
                newName: "IX_Cafes_CityId");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueCode",
                table: "Cafes",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Cafes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Cafes",
                type: "nvarchar(185)",
                maxLength: 185,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDesc",
                table: "Cafes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Cafes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FaTitle",
                table: "Cafes",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnTitle",
                table: "Cafes",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Cafes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafes",
                table: "Cafes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafes_City_CityId",
                table: "Cafes",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Cafes_CafeId",
                table: "MenuItem",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cafes_CafeId",
                table: "Users",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cafes_City_CityId",
                table: "Cafes");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_Cafes_CafeId",
                table: "MenuItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Cafes_CafeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cafes",
                table: "Cafes");

            migrationBuilder.RenameTable(
                name: "Cafes",
                newName: "Cafe");

            migrationBuilder.RenameIndex(
                name: "IX_Cafes_CityId",
                table: "Cafe",
                newName: "IX_Cafe_CityId");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueCode",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(185)",
                oldMaxLength: 185);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDesc",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "FaTitle",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(85)",
                oldMaxLength: 85);

            migrationBuilder.AlterColumn<string>(
                name: "EnTitle",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(85)",
                oldMaxLength: 85);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Cafe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cafe",
                table: "Cafe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cafe_City_CityId",
                table: "Cafe",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_Cafe_CafeId",
                table: "MenuItem",
                column: "CafeId",
                principalTable: "Cafe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Cafe_CafeId",
                table: "Users",
                column: "CafeId",
                principalTable: "Cafe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
