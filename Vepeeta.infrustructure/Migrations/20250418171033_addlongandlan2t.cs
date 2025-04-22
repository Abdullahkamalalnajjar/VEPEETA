using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vepeeta.infrustructure.Migrations
{
    public partial class addlongandlan2t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Doctor_Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doctor_Address",
                table: "AspNetUsers");
        }
    }
}
