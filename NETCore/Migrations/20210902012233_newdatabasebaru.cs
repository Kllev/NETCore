using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Migrations
{
    public partial class newdatabasebaru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterVM",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tb_m_persons",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_persons", x => x.NIK);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_university",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_university", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_accounts",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_accounts", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_tr_accounts_tb_m_persons_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_persons",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_m_educations_tb_m_university_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "tb_m_university",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_tr_profiling",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EducationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tr_profiling", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_tr_profiling_tb_m_educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "tb_m_educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_tr_profiling_tb_tr_accounts_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_tr_accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_educations_UniversityId",
                table: "tb_m_educations",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_tr_profiling_EducationId",
                table: "tb_tr_profiling",
                column: "EducationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterVM");

            migrationBuilder.DropTable(
                name: "tb_tr_profiling");

            migrationBuilder.DropTable(
                name: "tb_m_educations");

            migrationBuilder.DropTable(
                name: "tb_tr_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_university");

            migrationBuilder.DropTable(
                name: "tb_m_persons");
        }
    }
}
