using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyApp.Migrations
{
    /// <inheritdoc />
    public partial class Creation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MGR_SSN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MGR_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLocations",
                columns: table => new
                {
                    Location = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLocations", x => new { x.DepartmentNum, x.Location });
                    table.ForeignKey(
                        name: "FK_DepartmentLocations_Department_DepartmentNum",
                        column: x => x.DepartmentNum,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    SSN = table.Column<string>(type: "nvarchar(450)", nullable: false, defaultValueSql: "NEWID()"),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MGR_SSN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DeptNum = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_SSN", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DeptNum",
                        column: x => x.DeptNum,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_MGR_SSN",
                        column: x => x.MGR_SSN,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectNumber);
                    table.ForeignKey(
                        name: "FK_Project_Department_DepartmentNum",
                        column: x => x.DepartmentNum,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    EmployeeSSN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Relationship = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => new { x.EmployeeSSN, x.Name });
                    table.ForeignKey(
                        name: "FK_Dependent_Employee_EmployeeSSN",
                        column: x => x.EmployeeSSN,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorksOn",
                columns: table => new
                {
                    EmployeeSSN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectNumber = table.Column<int>(type: "int", nullable: false),
                    NumberOfHours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksOn", x => new { x.ProjectNumber, x.EmployeeSSN });
                    table.ForeignKey(
                        name: "FK_WorksOn_Employee_EmployeeSSN",
                        column: x => x.EmployeeSSN,
                        principalTable: "Employee",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorksOn_Project_ProjectNumber",
                        column: x => x.ProjectNumber,
                        principalTable: "Project",
                        principalColumn: "ProjectNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_MGR_SSN",
                table: "Department",
                column: "MGR_SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeptNum",
                table: "Employee",
                column: "DeptNum");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MGR_SSN",
                table: "Employee",
                column: "MGR_SSN");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DepartmentNum",
                table: "Project",
                column: "DepartmentNum");

            migrationBuilder.CreateIndex(
                name: "IX_WorksOn_EmployeeSSN",
                table: "WorksOn",
                column: "EmployeeSSN");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_MGR_SSN",
                table: "Department",
                column: "MGR_SSN",
                principalTable: "Employee",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_MGR_SSN",
                table: "Department");

            migrationBuilder.DropTable(
                name: "DepartmentLocations");

            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "WorksOn");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
