using Microsoft.EntityFrameworkCore.Migrations;

namespace OHD.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblStatus",
                columns: table => new
                {
                    StId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStatus", x => x.StId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_complaints_comp_status",
                table: "tbl_complaints",
                column: "comp_status");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_complaints_tblStatus_comp_status",
                table: "tbl_complaints",
                column: "comp_status",
                principalTable: "tblStatus",
                principalColumn: "StId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_complaints_tblStatus_comp_status",
                table: "tbl_complaints");

            migrationBuilder.DropTable(
                name: "tblStatus");

            migrationBuilder.DropIndex(
                name: "IX_tbl_complaints_comp_status",
                table: "tbl_complaints");
        }
    }
}
