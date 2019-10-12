using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.DataModel.Migrations
{
    public partial class sqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlackList",
                columns: table => new
                {
                    BlackListKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackList", x => x.BlackListKey);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentKey);
                });

            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    PurposeKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.PurposeKey);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleKey);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    EmployeeId = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentKey = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OfficePhone = table.Column<string>(maxLength: 50, nullable: true),
                    OfficePhoneExt = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 50, nullable: true),
                    Comments = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeKey);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentKey",
                        column: x => x.DepartmentKey,
                        principalTable: "Department",
                        principalColumn: "DepartmentKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    RoleKey = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    password_hash = table.Column<byte[]>(nullable: false),
                    password_salt = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserKey);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleKey",
                        column: x => x.RoleKey,
                        principalTable: "Role",
                        principalColumn: "RoleKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRequest",
                columns: table => new
                {
                    EmployeeRequestKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    EmployeeKey = table.Column<int>(nullable: false),
                    VisitorName = table.Column<string>(maxLength: 50, nullable: true),
                    VisitorEmail = table.Column<string>(maxLength: 50, nullable: true),
                    VisitorPhone = table.Column<string>(maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Company = table.Column<string>(maxLength: 50, nullable: true),
                    PurposeKey = table.Column<int>(nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Comments = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRequest", x => x.EmployeeRequestKey);
                    table.ForeignKey(
                        name: "FK_EmployeeRequest_Employee_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmployeeRequest_Purpose_PurposeKey",
                        column: x => x.PurposeKey,
                        principalTable: "Purpose",
                        principalColumn: "PurposeKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    VisitorKey = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDeleted = table.Column<byte>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TaxNumberVisitor = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Company = table.Column<string>(maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    PurposeKey = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeKey = table.Column<int>(nullable: false),
                    EmployeeRequestKey = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.VisitorKey);
                    table.ForeignKey(
                        name: "FK_Visitor_Employee_EmployeeKey",
                        column: x => x.EmployeeKey,
                        principalTable: "Employee",
                        principalColumn: "EmployeeKey",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visitor_Purpose_PurposeKey",
                        column: x => x.PurposeKey,
                        principalTable: "Purpose",
                        principalColumn: "PurposeKey",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentKey",
                table: "Employee",
                column: "DepartmentKey");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequest_EmployeeKey",
                table: "EmployeeRequest",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRequest_PurposeKey",
                table: "EmployeeRequest",
                column: "PurposeKey");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleKey",
                table: "User",
                column: "RoleKey");

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_EmployeeKey",
                table: "Visitor",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_PurposeKey",
                table: "Visitor",
                column: "PurposeKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlackList");

            migrationBuilder.DropTable(
                name: "EmployeeRequest");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Visitor");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
