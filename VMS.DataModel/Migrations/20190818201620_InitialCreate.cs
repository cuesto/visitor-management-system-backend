using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VMS.DataModel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlackList",
                columns: table => new
                {
                    BlackListKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<byte>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<byte>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.PurposeKey);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentKey = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    OfficePhone = table.Column<string>(maxLength: 50, nullable: true),
                    OfficePhoneExt = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    MobilePhone = table.Column<string>(maxLength: 50, nullable: true),
                    Comments = table.Column<string>(maxLength: 50, nullable: true),
                    Image = table.Column<string>(maxLength: 100, nullable: true),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<byte>(nullable: false)
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
                name: "EmployeeRequest",
                columns: table => new
                {
                    EmployeeRequestKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeKey = table.Column<int>(nullable: false),
                    VisitorName = table.Column<string>(maxLength: 50, nullable: true),
                    VisitorEmail = table.Column<string>(maxLength: 50, nullable: true),
                    VisitorPhone = table.Column<string>(maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Company = table.Column<string>(maxLength: 50, nullable: true),
                    PurposeKey = table.Column<int>(nullable: false),
                    BeginDate = table.Column<DateTime>(type: "date", nullable: true),
                    BeginTime = table.Column<TimeSpan>(nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndTime = table.Column<TimeSpan>(nullable: true),
                    Comments = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<byte>(nullable: false)
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
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TaxNumberVisitor = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Company = table.Column<string>(maxLength: 50, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    PurposeKey = table.Column<int>(nullable: false),
                    PurposeComment = table.Column<string>(maxLength: 100, nullable: true),
                    EmployeeKey = table.Column<int>(nullable: false),
                    DatetimeIn = table.Column<DateTime>(nullable: true),
                    DatetimeOut = table.Column<DateTime>(nullable: true),
                    EmployeeRequestKey = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(maxLength: 50, nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(maxLength: 50, nullable: true),
                    IsDeleted = table.Column<byte>(nullable: false)
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
                        name: "FK_Visitor_EmployeeRequest_EmployeeRequestKey",
                        column: x => x.EmployeeRequestKey,
                        principalTable: "EmployeeRequest",
                        principalColumn: "EmployeeRequestKey",
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
                name: "IX_Visitor_EmployeeKey",
                table: "Visitor",
                column: "EmployeeKey");

            migrationBuilder.CreateIndex(
                name: "IX_Visitor_EmployeeRequestKey",
                table: "Visitor",
                column: "EmployeeRequestKey");

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
                name: "Visitor");

            migrationBuilder.DropTable(
                name: "EmployeeRequest");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
