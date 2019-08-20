using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.DataModel.Migrations
{
    public partial class employeerequestmod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginDate",
                table: "EmployeeRequest");

            migrationBuilder.DropColumn(
                name: "BeginTime",
                table: "EmployeeRequest");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "EmployeeRequest",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "EmployeeRequest",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "EmployeeRequest",
                type: "time",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EmployeeRequest");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "EmployeeRequest");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "EmployeeRequest",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<DateTime>(
                name: "BeginDate",
                table: "EmployeeRequest",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "BeginTime",
                table: "EmployeeRequest",
                nullable: true);
        }
    }
}
