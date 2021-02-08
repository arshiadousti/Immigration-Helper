using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Mig_UpdateTestagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lang",
                table: "Tests");

            migrationBuilder.AddColumn<int>(
                name: "LangId",
                table: "Tests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LangId",
                table: "Tests",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Languages_LangId",
                table: "Tests",
                column: "LangId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Languages_LangId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_LangId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "LangId",
                table: "Tests");

            migrationBuilder.AddColumn<string>(
                name: "Lang",
                table: "Tests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
