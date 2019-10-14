using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.DataModel.Migrations
{
    public partial class sqlite_and_seed : Migration
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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "RoleKey", "Created", "CreatedBy", "Description", "IsDeleted", "Modified", "ModifiedBy", "Name" },
                values: new object[] { 1, new DateTime(2019, 10, 12, 10, 4, 28, 467, DateTimeKind.Local).AddTicks(9868), "System", "Administrator", (byte)0, null, null, "administrator" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserKey", "Created", "CreatedBy", "Email", "IsDeleted", "Modified", "ModifiedBy", "Name", "RoleKey", "password_hash", "password_salt" },
                values: new object[] { 1, new DateTime(2019, 10, 12, 10, 4, 28, 461, DateTimeKind.Local).AddTicks(8678), "System", "administrator@mail.com", (byte)0, null, null, "admin", 1, new byte[] { 37, 23, 222, 181, 199, 135, 95, 94, 253, 112, 16, 78, 15, 121, 110, 145, 226, 168, 232, 157, 25, 152, 179, 59, 202, 179, 158, 15, 214, 17, 190, 36, 35, 181, 108, 9, 236, 28, 16, 159, 163, 227, 15, 128, 220, 24, 126, 83, 212, 146, 122, 181, 197, 83, 98, 227, 225, 57, 102, 99, 216, 202, 143, 190 }, new byte[] { 165, 125, 10, 149, 251, 169, 130, 184, 78, 184, 179, 126, 218, 234, 121, 108, 50, 129, 119, 83, 133, 130, 114, 191, 115, 245, 67, 210, 109, 140, 186, 84, 34, 83, 177, 151, 0, 251, 52, 249, 101, 137, 26, 232, 214, 149, 244, 187, 32, 150, 110, 231, 21, 144, 136, 161, 187, 225, 218, 109, 73, 132, 8, 183, 221, 185, 233, 94, 19, 101, 147, 183, 114, 201, 77, 40, 93, 103, 124, 204, 47, 122, 220, 208, 155, 241, 233, 49, 103, 246, 25, 78, 184, 213, 99, 88, 191, 176, 10, 119, 145, 178, 179, 235, 159, 245, 70, 214, 118, 63, 162, 49, 156, 97, 221, 96, 162, 10, 191, 124, 20, 160, 100, 66, 128, 9, 7, 103 } });

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
