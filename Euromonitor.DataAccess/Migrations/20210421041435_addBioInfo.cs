using Microsoft.EntityFrameworkCore.Migrations;

namespace Euromonitor.DataAccess.Migrations
{
    public partial class addBioInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BioInfo",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BioInfo",
                table: "AppUser");
        }
    }
}
