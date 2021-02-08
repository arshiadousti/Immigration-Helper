using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_DegreeCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Degrees_DegreeId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeTests_Tests_TestId",
                table: "DegreeTests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_DegreeTests_TestId",
                table: "DegreeTests");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "DegreeTests");

            migrationBuilder.AlterColumn<int>(
                name: "DegreeId",
                table: "Tests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "DegreeTests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DegreeId",
                table: "Countries",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeTests_CountryId",
                table: "DegreeTests",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Degrees_DegreeId",
                table: "Countries",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeTests_Countries_CountryId",
                table: "DegreeTests",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Degrees_DegreeId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_DegreeTests_Countries_CountryId",
                table: "DegreeTests");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_DegreeTests_CountryId",
                table: "DegreeTests");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "DegreeTests");

            migrationBuilder.AlterColumn<int>(
                name: "DegreeId",
                table: "Tests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "DegreeTests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "DegreeId",
                table: "Countries",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DegreeTests_TestId",
                table: "DegreeTests",
                column: "TestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Degrees_DegreeId",
                table: "Countries",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeTests_Tests_TestId",
                table: "DegreeTests",
                column: "TestId",
                principalTable: "Tests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Degrees_DegreeId",
                table: "Tests",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
