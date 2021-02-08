using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_TestCounteyUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
                table: "TestCountries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId2",
                table: "TestCountries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TestUserId",
                table: "TestCountries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestUserId1",
                table: "TestCountries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestCountries_CountryId1",
                table: "TestCountries",
                column: "CountryId1");

            migrationBuilder.CreateIndex(
                name: "IX_TestCountries_TestUserId",
                table: "TestCountries",
                column: "TestUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestCountries_Countries_CountryId1",
                table: "TestCountries",
                column: "CountryId1",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TestCountries_Tests_TestUserId",
                table: "TestCountries",
                column: "TestUserId",
                principalTable: "Tests",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestCountries_Countries_CountryId1",
                table: "TestCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_TestCountries_Tests_TestUserId",
                table: "TestCountries");

            migrationBuilder.DropIndex(
                name: "IX_TestCountries_CountryId1",
                table: "TestCountries");

            migrationBuilder.DropIndex(
                name: "IX_TestCountries_TestUserId",
                table: "TestCountries");

            migrationBuilder.DropColumn(
                name: "CountryId1",
                table: "TestCountries");

            migrationBuilder.DropColumn(
                name: "CountryId2",
                table: "TestCountries");

            migrationBuilder.DropColumn(
                name: "TestUserId",
                table: "TestCountries");

            migrationBuilder.DropColumn(
                name: "TestUserId1",
                table: "TestCountries");
        }
    }
}
