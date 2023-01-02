using Microsoft.EntityFrameworkCore.Migrations;

namespace OHD.Migrations
{
    public partial class addimagecolumnfor_facilites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "faci_Image",
                table: "tbl_facilities",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "faci_Image",
                table: "tbl_facilities");
        }
    }
}
