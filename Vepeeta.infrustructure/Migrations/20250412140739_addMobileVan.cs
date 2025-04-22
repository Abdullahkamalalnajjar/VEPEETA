using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vepeeta.infrustructure.Migrations
{
    public partial class addMobileVan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommercialRegistrationLicensePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsGroomer",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVeterinarian",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoPath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Van_FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VeterinaryLicensePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VanServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseServicesId = table.Column<int>(type: "int", nullable: false),
                    VanId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanServices_AspNetUsers_VanId",
                        column: x => x.VanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VanServices_Services_BaseServicesId",
                        column: x => x.BaseServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VanWorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    From = table.Column<TimeSpan>(type: "time", nullable: false),
                    To = table.Column<TimeSpan>(type: "time", nullable: false),
                    VanId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanWorkingHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VanWorkingHours_AspNetUsers_VanId",
                        column: x => x.VanId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VanServices_BaseServicesId",
                table: "VanServices",
                column: "BaseServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_VanServices_VanId",
                table: "VanServices",
                column: "VanId");

            migrationBuilder.CreateIndex(
                name: "IX_VanWorkingHours_VanId",
                table: "VanWorkingHours",
                column: "VanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VanServices");

            migrationBuilder.DropTable(
                name: "VanWorkingHours");

            migrationBuilder.DropColumn(
                name: "CommercialRegistrationLicensePath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsGroomer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsVeterinarian",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePhotoPath",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Van_FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VeterinaryLicensePath",
                table: "AspNetUsers");
        }
    }
}
