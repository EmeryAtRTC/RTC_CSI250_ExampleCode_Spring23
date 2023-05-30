using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoShop23.Data.Migrations
{
    public partial class addedTechStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TechnicianStatusId",
                table: "Technicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TechnicianStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicianStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Technicians_TechnicianStatusId",
                table: "Technicians",
                column: "TechnicianStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technicians_TechnicianStatuses_TechnicianStatusId",
                table: "Technicians",
                column: "TechnicianStatusId",
                principalTable: "TechnicianStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technicians_TechnicianStatuses_TechnicianStatusId",
                table: "Technicians");

            migrationBuilder.DropTable(
                name: "TechnicianStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Technicians_TechnicianStatusId",
                table: "Technicians");

            migrationBuilder.DropColumn(
                name: "TechnicianStatusId",
                table: "Technicians");
        }
    }
}
