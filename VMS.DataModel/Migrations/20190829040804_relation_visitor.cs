using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.DataModel.Migrations
{
    public partial class relation_visitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitor_EmployeeRequest_EmployeeRequestKey",
                table: "Visitor");

            migrationBuilder.DropIndex(
                name: "IX_Visitor_EmployeeRequestKey",
                table: "Visitor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Visitor_EmployeeRequestKey",
                table: "Visitor",
                column: "EmployeeRequestKey");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitor_EmployeeRequest_EmployeeRequestKey",
                table: "Visitor",
                column: "EmployeeRequestKey",
                principalTable: "EmployeeRequest",
                principalColumn: "EmployeeRequestKey",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
