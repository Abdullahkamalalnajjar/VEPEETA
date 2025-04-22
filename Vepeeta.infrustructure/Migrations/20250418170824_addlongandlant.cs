using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vepeeta.infrustructure.Migrations
{
    public partial class addlongandlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Clinic_Latitude",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Clinic_Longitude",
                table: "AspNetUsers",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clinic_Latitude",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Clinic_Longitude",
                table: "AspNetUsers");
        }
    }
}
