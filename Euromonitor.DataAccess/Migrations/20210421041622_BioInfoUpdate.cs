using Microsoft.EntityFrameworkCore.Migrations;

namespace Euromonitor.DataAccess.Migrations
{
    public partial class BioInfoUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BioInfo",
                table: "AppUser",
                newName: "AppUserBioInfo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppUserBioInfo",
                table: "AppUser",
                newName: "BioInfo");
        }
    }
}
