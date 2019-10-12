using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.DataModel.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleKey", "Created", "CreatedBy", "Description", "IsDeleted", "Modified", "ModifiedBy", "Name" },
                values: new object[] { 1, new DateTime(2019, 10, 12, 8, 52, 41, 581, DateTimeKind.Local).AddTicks(25), "System", "Administrador", (byte)0, null, null, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "RoleKey",
                keyValue: 1);
        }
    }
}
