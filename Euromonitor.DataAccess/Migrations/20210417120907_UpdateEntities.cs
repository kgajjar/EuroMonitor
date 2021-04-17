using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Euromonitor.DataAccess.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "AppUserName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "AppUserLastName");

            migrationBuilder.RenameColumn(
                name: "LastActive",
                table: "Users",
                newName: "AppUserLastActive");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "AppUserFirstName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Users",
                newName: "AppUserEmailAddress");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Users",
                newName: "AppUserCreateDate");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Users",
                newName: "AppUserContactNumber");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "BookPurchasePrice");

            migrationBuilder.AddColumn<int>(
                name: "AppUserIsDeleted",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookCreateDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BookIsDeleted",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BookLastUpdated",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserIsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookCreateDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookIsDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookLastUpdated",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookName",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "AppUserName",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "AppUserLastName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "AppUserLastActive",
                table: "Users",
                newName: "LastActive");

            migrationBuilder.RenameColumn(
                name: "AppUserFirstName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "AppUserEmailAddress",
                table: "Users",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "AppUserCreateDate",
                table: "Users",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "AppUserContactNumber",
                table: "Users",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "BookPurchasePrice",
                table: "Books",
                newName: "Price");
        }
    }
}
