using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vepeeta.infrustructure.Migrations
{
    public partial class removeDoctorservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorServices");

            migrationBuilder.AddColumn<bool>(
                name: "isAudioCallAvailable",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isVideoCallAvailable",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isVisitHomeAvailable",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAudioCallAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isVideoCallAvailable",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "isVisitHomeAvailable",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "DoctorServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorServices_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorServices_DoctorId",
                table: "DoctorServices",
                column: "DoctorId");
        }
    }
}
