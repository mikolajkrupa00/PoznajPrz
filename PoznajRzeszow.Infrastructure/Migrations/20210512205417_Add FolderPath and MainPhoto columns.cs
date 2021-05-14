using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajRzeszow.Infrastructure.Migrations
{
    public partial class AddFolderPathandMainPhotocolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FolderPath",
                table: "Places",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainPhoto",
                table: "Places",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderPath",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "MainPhoto",
                table: "Places");
        }
    }
}
