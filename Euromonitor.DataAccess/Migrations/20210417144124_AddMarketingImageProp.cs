using Microsoft.EntityFrameworkCore.Migrations;

namespace Euromonitor.DataAccess.Migrations
{
    public partial class AddMarketingImageProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookMarketingImage",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookMarketingImage",
                table: "Book");
        }
    }
}
