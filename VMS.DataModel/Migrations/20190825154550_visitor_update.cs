using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.DataModel.Migrations
{
    public partial class visitor_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatetimeIn",
                table: "Visitor");

            migrationBuilder.DropColumn(
                name: "DatetimeOut",
                table: "Visitor");

            migrationBuilder.RenameColumn(
                name: "PurposeComment",
                table: "Visitor",
                newName: "Comment");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Visitor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Visitor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Visitor");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Visitor");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Visitor",
                newName: "PurposeComment");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatetimeIn",
                table: "Visitor",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatetimeOut",
                table: "Visitor",
                nullable: true);
        }
    }
}
