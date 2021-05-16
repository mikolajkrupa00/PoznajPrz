using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajRzeszow.Infrastructure.Migrations
{
    public partial class ChangeLatLngtypefromDecimaltoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Longitude",
                table: "Places",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<string>(
                name: "Latitude",
                table: "Places",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Places",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Places",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }
    }
}
