using Microsoft.EntityFrameworkCore.Migrations;

namespace Euromonitor.DataAccess.Migrations
{
    public partial class IsDeletedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubscriptionIsDelete",
                table: "AppUserBooks",
                newName: "SubscriptionIsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubscriptionIsDeleted",
                table: "AppUserBooks",
                newName: "SubscriptionIsDelete");
        }
    }
}
