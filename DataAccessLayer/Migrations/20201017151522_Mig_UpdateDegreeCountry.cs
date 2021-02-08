using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_UpdateDegreeCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Degrees_DegreeId",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Countries_DegreeId",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DegreeId",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegreeId",
                table: "Countries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DegreeId",
                table: "Countries",
                column: "DegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Degrees_DegreeId",
                table: "Countries",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
