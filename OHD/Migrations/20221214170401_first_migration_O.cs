using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OHD.Migrations
{
    public partial class first_migration_O : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_assignby_assignto");

            migrationBuilder.DropTable(
                name: "tbl_complaints");

            migrationBuilder.DropTable(
                name: "tbl_student_council");

            migrationBuilder.DropTable(
                name: "tbl_assignees");

            migrationBuilder.DropTable(
                name: "identity_registor");

            migrationBuilder.DropTable(
                name: "tbl_maintaines");

            migrationBuilder.DropTable(
                name: "tbl_lab");

            migrationBuilder.DropTable(
                name: "tbl_facilities");
        }
    }
}
