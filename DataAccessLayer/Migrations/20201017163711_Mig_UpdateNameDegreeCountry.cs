using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_UpdateNameDegreeCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeTests_Countries_CountryId",
                table: "DegreeTests");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeTests_Degrees_DegreeId",
                table: "DegreeTests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DegreeTests",
                table: "DegreeTests");

            migrationBuilder.RenameTable(
                name: "DegreeTests",
                newName: "DegreeCountries");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeTests_DegreeId",
                table: "DegreeCountries",
                newName: "IX_DegreeCountries_DegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeTests_CountryId",
                table: "DegreeCountries",
                newName: "IX_DegreeCountries_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DegreeCountries",
                table: "DegreeCountries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeCountries_Countries_CountryId",
                table: "DegreeCountries",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeCountries_Degrees_DegreeId",
                table: "DegreeCountries",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeCountries_Countries_CountryId",
                table: "DegreeCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeCountries_Degrees_DegreeId",
                table: "DegreeCountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DegreeCountries",
                table: "DegreeCountries");

            migrationBuilder.RenameTable(
                name: "DegreeCountries",
                newName: "DegreeTests");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeCountries_DegreeId",
                table: "DegreeTests",
                newName: "IX_DegreeTests_DegreeId");

            migrationBuilder.RenameIndex(
                name: "IX_DegreeCountries_CountryId",
                table: "DegreeTests",
                newName: "IX_DegreeTests_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DegreeTests",
                table: "DegreeTests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeTests_Countries_CountryId",
                table: "DegreeTests",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeTests_Degrees_DegreeId",
                table: "DegreeTests",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
