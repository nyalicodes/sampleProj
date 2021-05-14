using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Graduates",
                columns: table => new
                {
                    GraduateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GraduateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduates", x => x.GraduateId);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    AcademicHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.AcademicHistoryId);
                    table.ForeignKey(
                        name: "FK_History_Graduates_GraduateId",
                        column: x => x.GraduateId,
                        principalTable: "Graduates",
                        principalColumn: "GraduateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_GraduateId",
                table: "History",
                column: "GraduateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "Graduates");
        }
    }
}
