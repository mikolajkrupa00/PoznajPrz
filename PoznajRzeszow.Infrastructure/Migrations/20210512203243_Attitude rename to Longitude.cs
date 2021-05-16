using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajRzeszow.Infrastructure.Migrations
{
    public partial class AttituderenametoLongitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Attitude",
                table: "Places",
                newName: "Longitude");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Places",
                newName: "Attitude");
        }
    }
}
