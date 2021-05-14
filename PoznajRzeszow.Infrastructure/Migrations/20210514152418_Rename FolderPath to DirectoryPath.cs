using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajRzeszow.Infrastructure.Migrations
{
    public partial class RenameFolderPathtoDirectoryPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FolderPath",
                table: "Places",
                newName: "DirectoryPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DirectoryPath",
                table: "Places",
                newName: "FolderPath");
        }
    }
}
